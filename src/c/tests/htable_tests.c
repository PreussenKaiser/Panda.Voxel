#include <stdio.h>
#include "assert/assert.h"
#include "../src/hash_table/hash_table.h"

string_hash_table table;

void htable_init() {
    for (int i = 0; i < TABLE_LENGTH; i++) {
	table.values[i] = NULL;
    }
}

int enumerated_lookup(char* value) {
    for (int i = 0; i < TABLE_LENGTH; i++) {
	char* value = table.values[i];

	if (value != NULL) {
	    return i;
	}
    }

    return -1;
}

void htable_insert_happy() {
    // Arrange
    htable_init();
    char* name = "Bingus";

    // Act
    insert(&table, name);

    // Assert
    int value = enumerated_lookup(name);
    int failure = -1;

    assert_neq(&value, &failure);
}

int main() {
    htable_insert_happy();

    return 0;
}

