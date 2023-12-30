#include <stdio.h>
#include <stdlib.h>
#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include "renderer.h"
#include "../util/file.h"

const char *vertex_shader_source;
const char *fragment_shader_source;

void renderer_handle_error(const unsigned int vertex_shader, const unsigned int fragment_shader, const unsigned int shader_program)
{
    int success;
    const unsigned int log_buffer_length = 512;
    char log_buffer[log_buffer_length];

    glGetShaderiv(vertex_shader, GL_COMPILE_STATUS, &success);
    if (!success)
    {
	glGetShaderInfoLog(vertex_shader, log_buffer_length, NULL, log_buffer);
	printf("ERROR COMPILING VERTEX SHADER\n%s\n", log_buffer);
    }

    glGetShaderiv(fragment_shader, GL_COMPILE_STATUS, &success);
    if (!success)
    {
	glGetShaderInfoLog(fragment_shader, log_buffer_length, NULL, log_buffer);
	printf("ERROR COMPILING FRAGMENT SHADER\n%s\n", log_buffer);
    }

    glGetProgramiv(shader_program, GL_LINK_STATUS, &success);
    if (!success)
    {
	glGetProgramInfoLog(shader_program, log_buffer_length, NULL, log_buffer);
	printf("ERROR LINKING SHADER PROGRAM\n%s\n", log_buffer);
    }
}

int renderer_init(void)
{
    vertex_shader_source = file_read("res/shaders/basic.vs");
    fragment_shader_source = file_read("res/shaders/basic.fs");

    free((char *)vertex_shader_source);
    free((char *)fragment_shader_source);

    return 0;
}

void renderer_init_shaders(void)
{
    unsigned int vertex_shader = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vertex_shader, 1, &vertex_shader_source, NULL);
    glCompileShader(vertex_shader);

    unsigned int fragment_shader = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fragment_shader, 1, &fragment_shader_source, NULL);
    glCompileShader(fragment_shader);

    unsigned int shader_program = glCreateProgram();
    glAttachShader(shader_program, vertex_shader);
    glAttachShader(shader_program, fragment_shader);

    glLinkProgram(shader_program);
    glUseProgram(shader_program);

    glEnableVertexAttribArray(0);

    renderer_handle_error(vertex_shader, fragment_shader, shader_program);

    glDeleteShader(vertex_shader);
    glDeleteShader(fragment_shader);
}

void renderer_render(const float *vertices, const unsigned int vertex_length, const unsigned int *indices, const unsigned int index_length)
{
    renderer_init_shaders();

    glClearColor(0.2f, 0.3f, 0.3f, 1.0f);
    glClear(GL_COLOR_BUFFER_BIT);

    unsigned int vao, vbo, ebo;

    glGenVertexArrays(1, &vao);
    glBindVertexArray(vao);

    glGenBuffers(1, &vbo);
    glBindBuffer(GL_ARRAY_BUFFER, vbo);
    glBufferData(GL_ARRAY_BUFFER, sizeof vertices, vertices, GL_STATIC_DRAW);

    glGenBuffers(1, &ebo);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, ebo);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof indices, indices, GL_STATIC_DRAW);

    const unsigned int length_half = index_length / 2;
    glVertexAttribPointer(0, length_half, GL_FLOAT, GL_FALSE, length_half * sizeof(float), (void *)0);
    glDrawElements(GL_TRIANGLES, index_length, GL_UNSIGNED_INT, 0);
}
