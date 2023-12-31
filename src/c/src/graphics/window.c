#include <glad/glad.h>
#include <GLFW/glfw3.h>
#include <stdlib.h>
#include <stdbool.h>
#include "window.h"

void window_process_input();
void window_init_shaders(void);
void window_render(float vertices[], unsigned int indices[]);

struct Window
{
    GLFWwindow *handle;
};

struct Window window;

int window_init(const unsigned int width, const unsigned int height)
{
    int exit_code = 0;

    if (!glfwInit())
    {
	return WINDOW_ERROR;
    }

    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

    window.handle = glfwCreateWindow(width, height, "Panda.Voxel", NULL, NULL);
    if (window.handle == NULL)
    {
	exit_code = WINDOW_ERROR;

	goto error;
    }

    glfwMakeContextCurrent(window.handle);

    if (!gladLoadGLLoader((GLADloadproc)glfwGetProcAddress))
    {
	exit_code = WINDOW_ERROR;

	goto error;
    }

    glViewport(0, 0, width, height);

error:
    if (exit_code)
	glfwTerminate();

    return exit_code;
}

int window_loop(void (tick(void)))
{
    int exit_code = 0;

    if (window.handle == NULL)
    {
	exit_code = WINDOW_ERROR;

	goto error;
    }

    while (!glfwWindowShouldClose(window.handle))
    {
	window_process_input();
	tick();

	glfwSwapBuffers(window.handle);
	glfwPollEvents();
    }

error:
    glfwTerminate();

    return exit_code;
}

void window_process_input(void)
{
    if (window.handle == NULL)
    {
	glfwTerminate();
	exit(1);
    }

    if (glfwGetKey(window.handle, GLFW_KEY_ESCAPE))
	glfwSetWindowShouldClose(window.handle, true);
}

