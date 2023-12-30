#include <stdlib.h>
#include <stdio.h>
#include "file.h"

const char *file_read(const char *file_name)
{
    FILE *file = fopen(file_name, "r");

    fseek(file, 0, SEEK_END);
    long length = ftell(file);
    rewind(file);

    char *buffer = malloc(length + 1);
    fread(buffer, 1, length, file);
    fclose(file);

    buffer[length] = '\0';
    
    return buffer;
}

