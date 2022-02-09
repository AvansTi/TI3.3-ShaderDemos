uniform sampler2D s_texture;
uniform sampler2D s_texture2;
uniform float time;

in vec2 texCoord;
in vec3 color;


void main()
{
	vec4 offset = texture2D(s_texture2, texCoord + vec2(time*0.01, 0));

	vec4 col1 = texture2D(s_texture, texCoord + vec2(offset.x*0.03, offset.x*0.03));
	gl_FragColor = col1;
}