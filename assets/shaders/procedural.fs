uniform sampler2D s_texture;
in vec2 texCoord;
in vec3 color;

void main()
{
	float f = 1 + 0.5 * cos(texCoord.x*200) + 0.5 * sin(texCoord.y*200);
	gl_FragColor = vec4(f,f,f,1);
}