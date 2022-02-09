#version 330
uniform sampler2D s_texture;
uniform float time;

in vec2 texCoord;

void main()
{
	float dist = max(abs(texCoord.x - 0.5), abs(texCoord.y - 0.5));

	float pixelSize = 200 + 200 * sin(time);


	if(dist < 0.3)
		gl_FragColor = texture2D(s_texture, round(texCoord*vec2(pixelSize,pixelSize))/vec2(pixelSize, pixelSize));
	else
		gl_FragColor= texture2D(s_texture, texCoord);

}