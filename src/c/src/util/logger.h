#ifndef LOGGER
#define LOGGER

typedef char logmsg_t[];

void log_inf(const logmsg_t msg);
void log_dbg(const logmsg_t msg);
void log_wrn(const logmsg_t msg);
void log_err(const logmsg_t msg);

#endif
