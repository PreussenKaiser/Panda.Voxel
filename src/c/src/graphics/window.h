#ifndef WINDOW
#define WINDOW

#define WINDOW_ERROR 1;

int window_init(const unsigned int width, const unsigned int height);
int window_loop(void (tick(void)));

#endif
