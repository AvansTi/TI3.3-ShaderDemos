#version 330

layout (location = 0) in vec3 a_position;
layout (location = 1) in vec3 a_color;
layout (location = 2) in vec2 a_texcoord;
layout (location = 3) in vec3 a_normal;

uniform mat4 modelViewProjectionMatrix;
uniform mat4 modelMatrix;
uniform mat3 normalMatrix;

out vec3 color;
out vec2 texCoord;
out vec3 normal;
out vec3 position;

void main()
{
	texCoord = a_texcoord;
	color = a_color;
	normal = normalMatrix * a_normal;
	position = vec3(modelMatrix * vec4(a_position,1));
	gl_Position = modelViewProjectionMatrix * vec4(a_position,1);
}