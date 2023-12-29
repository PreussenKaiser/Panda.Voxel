#ifndef WINDOW
#define WINDOW

#include <GLFW/glfw3.h>

#define WINDOW_ERROR 1;

int window_init(const unsigned int width, const unsigned int height);
int window_loop(void (tick(void)));

#endif
