#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include "renderer.h"

void renderer_render(const float vertices[], const unsigned int indices)
{
    unsigned int vao;
    glGenVertexArrays(1, &vao);
    glBindVertexArray(vao);
}
