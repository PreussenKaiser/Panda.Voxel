#include "game.h"

typedef struct { FGame init, update; } Game;
Game game;

int game_init(FGame init, FGame update)
{
    game.init = init;
    game.update = update;

    return 0;
}

int game_run(void)
{
    int exit_code = 0;

    exit_code = game.init();
    if (exit_code)
	goto end;

    exit_code = game.update();
    if (exit_code)
	goto end;

end:
    return exit_code;
}
