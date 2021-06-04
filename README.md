# CountTimer
CountTimer for your Unity game
US - Please keep credited the code 
BR - Por favor mantenha creditado o código 

![image](https://user-images.githubusercontent.com/33985180/120748557-5d779f00-c4d9-11eb-943f-b7d05005f2bc.png)

US - Drag the "CountTimer" script into your project.
Then in your script import the library
Using TimerCount;

BR - Arraste o script “CountTimer” para o seu projeto.
Em seguida no seu script importe a biblioteca
Using TimerCount;

![image](https://user-images.githubusercontent.com/33985180/120748451-2dc89700-c4d9-11eb-9c2f-7b5ba88c3d7d.png)

US - After importing TimerCount, create a variable of type CountTimer.
and in Start start this variable as new CountTimer(this).
The "this" parameter passes to the CountTimer the instantiation of the MonoBehavior class that is calling it.

BR - Após importar TimerCount , crie uma variável do tipo CountTimer.
e no Start inicie esta variável como new CountTimer(this).
O parâmetro “this” passar para o CountTimer a instancia da classe MonoBehavior que esta chamando ele .

![image](https://user-images.githubusercontent.com/33985180/120833322-048b2380-c538-11eb-86fd-f0ab068dc823.png)

US - CountDown() takes 3 parameters int time, a function to execute at the end of the time, and an object to visualize time, Text, or a Slide. The function, and the TimerView can be null if necessary.

BR - CountDown()  leva 3 parâmetros  int tempo, uma função para executar ao final do time, e um objeto para visualizar o tempo, Text ou um Slide. A função, e o TimerView pode ser nulo caso haja necessidade.

![image](https://user-images.githubusercontent.com/33985180/120833741-89763d00-c538-11eb-8b71-c84c1fc54985.png)

US - CountDownUnscaled(). Equal the CountDown function, but it is not affected by the Time.Scale of your project.

BR - CountDownUnscaled(). Igual a função CountDown , porém ela não é afetado pelo Time.Scale do seu projeto.

![image](https://user-images.githubusercontent.com/33985180/120834027-dd812180-c538-11eb-8c80-afebcbaf9a76.png)

US - StopCountDown() for the timer called by your class.

BR - StopCountDown() para o timer chamada pela sua classe.

![image](https://user-images.githubusercontent.com/33985180/120834516-816acd00-c539-11eb-8ea7-a38740616b4a.png)

US - CountEvent(). It will generate an event every time determined by you through its parameter.
playCountEvent = true/false, will start or stop the event.
OnTimerEvent+=YouFuncions; you will hear the event and each time it is triggered it will perform the function passed to it.

BR - CountEvent(). Irá gerar um evento a cada tempo determinado por você através de seu parâmetro.
playCountEvent = true/false, irá iniciar ou parar o evento.
OnTimerEvent+=YouFuncions; ficará ouvindo o evento e cada vez que ele for disparado executará a função passada para ele.

![image](https://user-images.githubusercontent.com/33985180/120834932-12da3f00-c53a-11eb-9fd3-9fefdf79f7cc.png)

US - Also having the option function to give play in the event in an Unscaled way that does not suffer interference from your Time.Scale;

BR - Tendo também a função opção de dar play no evento de forma Unscaled que não sofre interferência do seu Time.Scale;


