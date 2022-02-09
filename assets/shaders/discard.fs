uniform sampler2D s_texture;
in vec2 texCoord;
in vec3 color;
in vec3 position;

void main()
{
	vec4 texColor = texture2D(s_texture, texCoord);
	if(texColor.b > 0.4 && texColor.r < 0.3 && texColor.g < 0.3)
		discard;

	if(position.z > 0)
		discard;



	gl_FragColor = texColor;
}