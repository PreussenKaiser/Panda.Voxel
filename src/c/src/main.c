#include <stdio.h>
#include <string.h>
#include "graphics/window.h"
#include "graphics/renderer.h"
#include "util/array.h"
#include "util/logger.h"

#define UNKNOWN_GAPI 2;
#define INVALID_ARGS 3;

void render(void);

int main(void)
{
    window_init(800, 600);
    window_loop(render);

    return 0;
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

    renderer_render(vertices, sizeof vertices, indices, ARRAY_SIZE(indices), sizeof indices);
}
