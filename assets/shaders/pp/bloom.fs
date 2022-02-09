#version 330
uniform sampler2D s_texture;
uniform float time;

in vec2 texCoord;

void main()
{
	float offset = 0.002;
    vec4 color = texture2D(s_texture, texCoord + vec2(offset, 0)) +
				 texture2D(s_texture, texCoord + vec2(-offset, 0)) +
				 texture2D(s_texture, texCoord + vec2(0, offset)) +
				 texture2D(s_texture, texCoord + vec2(0, -offset));
	color = color / 4.0 + texture2D(s_texture, texCoord);

	gl_FragColor = color;
}