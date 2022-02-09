uniform sampler2D s_texture;
uniform float time;

in vec2 texCoord;
in vec3 color;


void main()
{
	vec4 finalColor = texture2D(s_texture, texCoord + vec2(0.25 * sin(time + texCoord.x),0.15 * sin(time + texCoord.y*2)));

	gl_FragColor =  finalColor;
}