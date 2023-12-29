#include <stdio.h>
#include "graphics/window.h"
#include "graphics/renderer.h"

void render(void);
void handle_error(int error_code);

// TODO: i think this error handling sucks
int main(void)
{
    int exit_code = 0;

    exit_code = window_init(800, 600);
    if (exit_code)
	goto error;

    exit_code = window_loop(render);
    if (exit_code)
	goto error;

error:
    if (exit_code)
	handle_error(exit_code);

    return exit_code;
}

void render(void)
{
    float vertices[] = {
	0.5f, 0.5f, 0.0f,
	0.5f, -0.5f, 0.0f,
	-0.5f, -0.5f, 0.0f,
	-0.5f, 0.5f, 0.0f
    };
    unsigned int indices[] = {
	0, 1, 3,
	1, 2, 3
    };
}

void handle_error(const int error_code)
{
    char *error_message;
    switch (error_code)
    {
	case 1:
	    error_message = "There was an error with the window";
	    break;

	default:
	    error_message = "Unknown error code";
    }

    fprintf(stderr, "%s\n", error_message);
}
