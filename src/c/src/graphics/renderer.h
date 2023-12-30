#ifndef RENDERER
#define RENDERER

int renderer_init(void);
void renderer_render(const float *vertices, const unsigned int vertex_length, const unsigned int *indices, const unsigned int index_length);

#endif
