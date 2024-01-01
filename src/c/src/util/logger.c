#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include "logger.h"

typedef unsigned int loglvl_t;
void logmsg(const logmsg_t msg, loglvl_t lvl);

void log_inf(const logmsg_t msg)
{
    logmsg(msg, 0);
}

void log_dbg(const logmsg_t msg)
{
    logmsg(msg, 1);
}

void log_wrn(const logmsg_t msg)
{
    logmsg(msg, 2);
}

void log_err(const logmsg_t msg)
{
    logmsg(msg, 3);
    fprintf(stderr, "%s\n", msg);

    exit(2);
}

void logmsg(const logmsg_t msg, const loglvl_t lvl)
{
    printf("[%d]: %s\n", lvl, msg);
}
