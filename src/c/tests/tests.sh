#!/bin/bash

cd tests

mkdir -p tmp

for FILE in *.c
do
    TEST_NAME=$(echo "${FILE%.*}")
    echo "Running ${TEST_NAME}"

    OUTPUT="${TEST_NAME}.exe"
    gcc $FILE assert/assert.c ../src/hash_table/hash_table.c -o tmp/$OUTPUT

    ./tmp/$OUTPUT
done

rm -r tmp

cd ..
