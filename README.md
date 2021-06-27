# Cozmo simulation project by Ferry Liekens and Frank Ladage
<p>This project consist of a Unity project using ml-agent to simulate the "Cozmo" Robot in a virtual environment. It uses reinforcement learning to train the model to improve. The task is simple: The robot is inside a box, a ball gets pushed towards the back wall and the robot needs to stop the ball from hitting it. Each time it succeeds it gets a point and when it fails it loses one. Note that the model is not trained properly yet so performance is pretty bad.


## preparation steps
<b>preparation steps</b>
<br/><br/>
<br /><b>Step 1</b> Install Unity 2020.3.X or higher
<br/><br/>
<b>Step 2</b> Clone this repository: https://github.com/ferryliekens/image_recognition.git
<br/><br/>

## Running the model steps
<b>How to run the model</b>
<br/><br/>
<br /><b>Step 1</b> Open the "CozmoInAction" scene
<br/><br/>
<b>Step 2</b> After training the model, Copy the .onx file that is located in \Cozmo simulation\results\ppo after training inside the assets folder and drag it into the model reference inside the Cozmo object in the "behaviour parameters" component
<br/><br/>

## Steps for training the model
<b>Optional steps for training the model</b>
<b>Step 1</b> Create a new virtual environment, or use the one provided
<pre>
python -m venv example
</pre>
<br/>
<b>Step 2</b> Activate your virtual environment
<pre>
.\venv\Scripts\example
</pre>
<br/>
<b>Step 3</b> Install pip, ml-agent and pytorch
<pre>
python -m pip install --upgrade pip
pip install torch==1.7.0 -f https://download.pytorch.org/whl/torch_stable.html
pip install mlagents
</pre>
<br/>
<b>Step 5</b> To train the model open the scene "Training scene" and run "mlagents-learn --run-id=exampleModelName" in your venv. after mlagent has started you can start the scene and the training will begin!
<b>Step 6</b> To continue to train the model run for example command: "mlagents-learn config/[insert model name].yaml --initialize-from=HoldBallBehaviour --run-id=HoldBallBehaviour2"
