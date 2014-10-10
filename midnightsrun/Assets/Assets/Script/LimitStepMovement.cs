using UnityEngine;
using System.Collections;

public class LimitStepMovement : MonoBehaviour {

		
		public float velocity = 0.001f;
		
		private float xPos;
		private float yPos;
		
		public int maxAmountSteps_Time = 1;
		
		private bool isFlipped;
		private bool max;
		
		public bool verticalMovement;
		

		
		// Use this for initialization
		void Start ()
		{
			xPos = transform.position.x;
			yPos = transform.position.y;
		}
		
		// Update is called once per frame
		void Update ()
		{
						//tells it to walk max amount of steps
						if (verticalMovement) 
						{ //vertical
								if (transform.position.y >= yPos + maxAmountSteps_Time) {
										max = true;
								} else if (transform.position.y <= yPos) {
										max = false;
								}
						} else { //horizontal
								if (transform.position.x >= xPos + maxAmountSteps_Time) {
										max = true;
								} else if (transform.position.x <= xPos) {
										max = false;
								}
						}
				
						if (verticalMovement) 
						{
							if (!max) 
							{
								transform.position = new Vector2 (transform.position.x, transform.position.y + velocity);
							} 
							else 
							{
								transform.position = new Vector2 (transform.position.x, transform.position.y - velocity);
							}
						} 
						else 
						{ //horizontal
								
							if (!max) 
							{
								transform.position = new Vector2 (transform.position.x + velocity, transform.position.y);
								if (isFlipped)
								{
									transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
									isFlipped = false;
								}
							} 
							else 
							{
								transform.position = new Vector2 (transform.position.x - velocity, transform.position.y);
								if (!isFlipped)
								{
									transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
									isFlipped = true;
								}
							}
						}
		}
}