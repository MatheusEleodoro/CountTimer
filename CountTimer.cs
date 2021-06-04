/* @author Matheus Eleodoro <matheuseleodoro@gmail.com>
 * Portifolio/Instagram @eleodoro.dev
 * Tutorial : https://www.youtube.com/channel/UCqguk1_yAPdcMYHHxAt7tVg
 * 
 * Free license, but be nice to leave my credits in the script :)
 * Licença livre, mas seja legal de deixar meus creditos no script :)
*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace TimerCount
{
    public class CountTimer
    {
        #region Variables 
        private Text time_UI;
        private int time;
        private bool pause;
        private MonoBehaviour mono;

        private IEnumerator enumerator;
        private IEnumerator enumeratorEvent;
        [SerializeField]private int timeEvent;
        [SerializeField]private bool isRunning;
        [SerializeField] private bool startOnAwake;
        #endregion

        public bool pauseTimer { set => pause = value; get => pause; }
        public bool playCountEvent
        {
            set
            {
                if (value)
                {
                    enumeratorEvent = TimerEvents(); mono.StartCoroutine(enumeratorEvent);
                }
                else
                {
                    mono.StopCoroutine(enumeratorEvent);
                }
            }
        }

        public bool playCountEventUnscaled
        {
            set
            {
                if (value)
                {
                    enumeratorEvent = TimerEventsUnscaled(); mono.StartCoroutine(enumeratorEvent);
                }
                else
                {
                    mono.StopCoroutine(enumeratorEvent);
                }
            }
        }

        public event Action OnTimerEvent;

        public CountTimer(MonoBehaviour classInstance)
        {
            mono = classInstance;
            isRunning = enumerator != null;
            timeEvent = 0;
            pause = false;
            time = 0;
        }

        /// <summary>
        /// Countdown for your game.
        /// </summary>
        /// <param name="time">Time to take action.</param>
        /// <param name="funcion">Action to be executed when the timer is finished.</param>
        /// <param name="timerView">GameObject with text or slider.</param>
        public void CountDown(int time, Action funcion = null, object timerView = null)
        {
            Slider sliderCount = null;
            Text textCount = null;
            if (timerView as GameObject != null)
            {
                sliderCount = (timerView as GameObject).GetComponent<Slider>();
                if (sliderCount == null)
                {
                    textCount = (timerView as GameObject).GetComponent<Text>();
                }

                if (textCount == null && sliderCount == null)
                {
                    Debug.LogWarning("<color=#ff3300><b>The gameobject provided does not contain any Slider or Text</b></color>");
                }
            }
            else if (timerView as Slider != null)
            {
                sliderCount = (timerView as Slider);
            }
            else if (timerView as Text != null)
            {
                textCount = (timerView as Text);
            }

            this.time = time;

            if (sliderCount != null)
            {
                sliderCount.maxValue = time;
                sliderCount.minValue = 0;
                sliderCount.value = sliderCount.maxValue;
                sliderCount.gameObject.SetActive(true);
                enumerator = TimerCountDownSlider(time, sliderCount, funcion);
                mono.StartCoroutine(enumerator);
            }
            else if (textCount != null)
            {
                textCount.text = time.ToString();
                textCount.gameObject.SetActive(true);
                enumerator = TimerCountDownText(time, textCount, funcion);
                mono.StartCoroutine(enumerator);
            }
            else
            {
                enumerator = TimerCountDown(time, funcion);
                mono.StartCoroutine(enumerator);
            }

            isRunning = enumerator != null;
        }

        /// <summary>
        /// Countdown Unscaled for your game.
        /// </summary>
        /// <param name="time">Time to take action.</param>
        /// <param name="funcion">Action to be executed when the timer is finished.</param>
        /// <param name="timerView">GameObject with text or slider.</param>
        public void CountDownUnscaled(int time, Action funcion = null, object timerView = null)
        {
            Slider sliderCount = null;
            Text textCount = null;
            if (timerView as GameObject != null)
            {
                sliderCount = (timerView as GameObject).GetComponent<Slider>();
                if (sliderCount == null)
                {
                    textCount = (timerView as GameObject).GetComponent<Text>();
                }

                if (textCount == null && sliderCount == null)
                {
                    Debug.LogWarning("<color=#ff3300><b>The gameobject provided does not contain any Slider or Text</b></color>");

                }
            }
            else if (timerView as Slider != null)
            {
                sliderCount = (timerView as Slider);
            }
            else if (timerView as Text != null)
            {
                textCount = (timerView as Text);
            }

            this.time = time;

            if (sliderCount != null)
            {
                sliderCount.maxValue = time;
                sliderCount.minValue = 0;
                sliderCount.value = sliderCount.maxValue;
                sliderCount.gameObject.SetActive(true);
                enumerator = TimerCountDownSliderUnscaled(time, sliderCount, funcion);
                mono.StartCoroutine(enumerator);
            }
            else if (textCount != null)
            {
                textCount.text = time.ToString();
                textCount.gameObject.SetActive(true);
                enumerator = TimerCountDownTextUnscaled(time, textCount, funcion);
                mono.StartCoroutine(enumerator);
            }
            else
            {
                enumerator = TimerCountDown(time, funcion);
                mono.StartCoroutine(enumerator);
            }
        }

        /// <summary>
        /// Trigger events every time interval
        /// </summary>
        /// <param name="time">Time to take event.</param>
        public void CountEvent(int time) => timeEvent = time;
  
        public void StopCountDown()
        {
            mono.StopCoroutine(enumerator);
        }

    

        #region  COROUTINES
        private IEnumerator TimerCountDown(int timer, Action funcion)
        {
            while (timer > 0)
            {
                yield return new WaitForSeconds(1f);
                if (!pause)
                    timer--;
            }
            funcion?.Invoke();
            enumerator = null;
            isRunning = false;
        }

        private IEnumerator TimerCountDownSlider(int timer, Slider s_timer, Action funcion)
        {
            while (timer > 0)
            {
                yield return new WaitForSeconds(1f);
                if (!pause)
                {
                    timer--;
                    s_timer.value--;
                }
            }
            s_timer.gameObject.SetActive(false);
            funcion?.Invoke();
            enumerator = null;
            isRunning = false;
        }

        private IEnumerator TimerCountDownText(int timer, Text t_timer, Action funcion)
        {
            while (timer > 0)
            {
                yield return new WaitForSeconds(1f);
                if (!pause)
                {
                    timer--;
                    t_timer.text = timer.ToString();
                }
            }
            t_timer.gameObject.SetActive(false);
            funcion?.Invoke();
            enumerator = null;
            isRunning = false;
        }

        private IEnumerator TimerCountDownUnscaled(int timer, Action funcion)
        {
            while (timer > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                if (!pause)
                    timer--;
            }
            funcion?.Invoke();
            enumerator = null;
            isRunning = false;
        }

        private IEnumerator TimerCountDownSliderUnscaled(int timer, Slider s_timer, Action funcion)
        {
            while (timer > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                if (!pause)
                {
                    timer--;
                    s_timer.value--;
                }
            }
            s_timer.gameObject.SetActive(false);
            funcion?.Invoke();
            enumerator = null;
            isRunning = false;
        }

        private IEnumerator TimerCountDownTextUnscaled(int timer, Text t_timer, Action funcion)
        {
            while (timer > 0)
            {
                yield return new WaitForSecondsRealtime(1f);
                if (!pause)
                {
                    timer--;
                    t_timer.text = timer.ToString();
                }
            }
            t_timer.gameObject.SetActive(false);
            funcion?.Invoke();
            enumerator = null;
            isRunning = false;
        }

        private IEnumerator TimerEvents()
        {
            while (timeEvent > 0)
            {
                yield return new WaitForSeconds(timeEvent);
                OnTimerEvent?.Invoke();
            }
        }

        private IEnumerator TimerEventsUnscaled()
        {
            while (timeEvent > 0)
            {
                yield return new WaitForSecondsRealtime(timeEvent);
                OnTimerEvent?.Invoke();
            }
        }

    }
    #endregion

}

