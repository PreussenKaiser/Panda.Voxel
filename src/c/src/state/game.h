#ifndef GAME
#define GAME

typedef int (*FGame)();

int game_init(FGame init, FGame update);
int game_run(void);

#endif
