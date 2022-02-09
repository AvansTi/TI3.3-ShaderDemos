#version 330
uniform sampler2D s_texture;
uniform sampler2D s_texture2;
uniform float time;

in vec2 texCoord;


void main()
{
	float offset = 0.004;
	vec4 color = texture2D(s_texture, texCoord);
	vec4 outline = texture2D(s_texture2, texCoord) -
				   0.25*texture2D(s_texture2, texCoord + vec2(-offset, 0)) -
				   0.25*texture2D(s_texture2, texCoord + vec2(offset, 0)) -
				   0.25*texture2D(s_texture2, texCoord + vec2(0, -offset)) -
				   0.25*texture2D(s_texture2, texCoord + vec2(0, offset));

	gl_FragColor = color + 10*vec4(outline.r, outline.g, outline.b, 1);
}