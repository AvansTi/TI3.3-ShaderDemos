uniform sampler2D s_texture;
uniform float time;

in vec2 texCoord;
in vec3 color;


void main()
{
	vec4 finalColor = texture2D(s_texture, texCoord + vec2(time*.2,time*.1));
	finalColor.a = 1;

	gl_FragColor =  finalColor;
}