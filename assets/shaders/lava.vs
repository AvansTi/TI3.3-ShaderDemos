#version 330

layout (location = 0) in vec3 a_position;
layout (location = 1) in vec3 a_color;
layout (location = 2) in vec2 a_texcoord;

uniform mat4 modelViewProjectionMatrix;
uniform float time;
out vec3 color;
out vec2 texCoord;


void main()
{
	texCoord = a_texcoord;
	color = a_color;
	gl_Position = modelViewProjectionMatrix * vec4(a_position,1);
}