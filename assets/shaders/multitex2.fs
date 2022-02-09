uniform sampler2D s_texture;
uniform sampler2D s_texture2;
uniform float time;

in vec2 texCoord;
in vec3 color;
in vec3 position;
#define PI 3.1415926535897932384626433832795

void main()
{
	vec4 col1 = texture2D(s_texture, texCoord);
	vec4 col2 = texture2D(s_texture2, texCoord);
	
	float angle = atan2(position.z, position.x)/(PI*2);
	if(angle > 1)
		angle--;
	if(angle < 0)
		angle++;

	//angle += fmod(time/10,1);
	while(angle > 1)
		angle--;
	while(angle < 0)
		angle++;

	angle = 1-(0.5 + 0.5 * sin(2*PI*angle));


	gl_FragColor = mix(col1, col2, clamp(angle,0,1) );
	
	//gl_FragColor = vec4(angle,angle,angle,1);

}