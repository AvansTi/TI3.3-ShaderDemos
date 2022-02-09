#version 330
uniform sampler2D s_texture;
uniform sampler2D s_distort;
uniform float time;

in vec2 texCoord;

void main()
{
	float distortion = 0.2 * (-1 + 2 * texture2D(s_distort, 20*texCoord + vec2(sin(time)*.1, time*.1)).x);
		distortion += 1 * (-1.0 + 2.0 * texture2D(s_distort, texCoord + vec2(sin(time)*.1, time*.1)).x);
	vec4 color = texture2D(s_texture, texCoord+distortion*0.02);
	
	color.b += 0.3;
	color.r -= 0.1;
	color.g -= 0.1;


	color *= vec4(0.5, 0.5, 1.2, 1.0);

	gl_FragColor = color;
}