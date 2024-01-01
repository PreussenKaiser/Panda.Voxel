#include <stdio.h>
#include "assert.h"

void assert(int condition) {
    if (!condition) {
	printf("Failure | Expected: true, Actual: false\n");
    }
}

void assert_eq(void* val1, void* val2) {
    int is_equal = val1 == val2;

    if (!is_equal) {
	printf("Failure | %p and %p are not equal\n", val1, val2);
    }
}

void assert_neq(void* val1, void* val2) {
    int is_equal = val1 == val2;

    if (is_equal) {
	printf("Failure | %p and %p are equal\n", val1, val2);
    }
}
