#include <stdio.h>
#include <string.h>
#include "state/game.h"
#include "graphics/window.h"
#include "graphics/renderer.h"
#include "util/array.h"

#define UNKNOWN_GAPI 2;
#define INVALID_ARGS 3;

int init(void);
int update(void);
void render(void);
void handle_error(int error_code);

// TODO: i think this error handling sucks
int main(const int argc, const char **argv)
{
    int exit_code;
    if (argc < 1)
    {
	exit_code = INVALID_ARGS
	goto error;
    }

    if (!strcmp(argv[1], "opengl"))
    {
	game_init(init, update);
	exit_code = game_run();
    }
    else
    {
	exit_code = UNKNOWN_GAPI;
    }

error:
    if (exit_code)
	handle_error(exit_code);

    return exit_code;
}

int init(void)
{
    window_init(800, 600);
    renderer_init();

    return 0;
}

int update(void)
{
    int exit_code = window_loop(render);

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

    renderer_render(vertices, ARRAY_SIZE(vertices), indices, ARRAY_SIZE(indices));
}

void handle_error(const int error_code)
{
    char *error_message;
    switch (error_code)
    {
	case 1:
	    error_message = "There was an error with the window";
	    break;

	case 2:
	    error_message = "Unknown graphics API";
	    break;

	case 3:
	    error_message = "Invalid arguments";
	    break;

	default:
	    error_message = "Unknown error code";
    }

    fprintf(stderr, "%s\n", error_message);
}
