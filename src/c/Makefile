CC = gcc
LIBS = glfw3
SOURCE_FILES = src/*.c src/*/*.c lib/*.c
ARGS = opengl

build:
	@echo '--- Building ---'
	@mkdir -p out
	@${CC} $(pkg-config --cflags ${LIBS}) -o out/test.exe ${SOURCE_FILES} $(pkg-config --static --libs ${LIBS}) -lglfw3 -lGL -lX11 -lpthread -lXrandr -lXi -ldl -lm
	@echo '--- Finished ---'

run: build
	@echo '--- Running ---'
	@./out/test.exe ${ARGS}
	@echo '--- Finished ---'

clean:
	@echo '--- Cleaning ---'
	@rm -rf out
	@echo '--- Finished ---'

