using System;
using System.Collections;
using System.Collections.Generic;
using DASUnityFramework.Scripts.ExtensionMethods;
using UnityEngine;
using UnityEngine.UI;

namespace DASUnityFramework.Scripts
{
    public static class GenericCoroutines
    {
        public delegate bool Condition();

        /// <summary>
        /// Suspends coroutine execution until condition evaluates to true.
        /// </summary>
        public static IEnumerator DoAfterCondition(Action action, Condition condition)
        {
            yield return new WaitUntil(() => condition());
            action();
        }

        /// <summary>
        /// Suspends coroutine execution for given number of seconds.
        /// </summary>
        public static IEnumerator DoAfterSeconds(Action action, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            action();
        }

        public static IEnumerator DoEveryXSeconds(Action action, float seconds, Condition endCondition = null)
        {
	        while (endCondition == null || endCondition() == false)
	        {
		        action();
		        yield return new WaitForSeconds(seconds);
	        }
        }

        /// <summary>
        /// Suspends coroutine execution for given number of frames.
        /// </summary>
        public static IEnumerator DoAfterFrames(Action action, int numFrames = 1)
        {
            int framesWaited = 0;
            while (framesWaited < numFrames)
            {
                yield return new WaitForEndOfFrame();
                framesWaited++;
            }

            action();
        }

        /// <summary>
        /// Interpolates object's position linearly away from a given point,
        /// relative to a given center point.
        /// </summary>
        /// <param name="interpolationType">Currently unused</param>
        public static IEnumerator MoveAwayFrom(Transform objectToMove, Vector3 myCenterPoint, Vector3 awayFrom,
            float distance, float seconds, InterpolationType interpolationType = InterpolationType.Linear, Action doAfter = null)
        {
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            Vector3 endPos = startingPos + (myCenterPoint - awayFrom).normalized * distance;
            while (elapsedTime < seconds)
            {
                objectToMove.position = Vector3.Lerp(startingPos, endPos, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.position = endPos;

            doAfter?.Invoke();
        }

        /// <summary>
        /// Interpolate object's position over a given duration.
        /// </summary>
        public static IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds, InterpolationType interpolationType = InterpolationType.Linear, Action onFinish = null)
        {
            return MoveAndRotateOverSeconds(objectToMove, end, objectToMove.transform.rotation, seconds, interpolationType, onFinish);
        }

        /// <summary>
        /// Interpolate object's position and rotation over a given duration.
        /// </summary>
        public static IEnumerator MoveAndRotateOverSeconds(GameObject objectToMove, Vector3 endPos, Quaternion endRot, float seconds, InterpolationType interpolationType = InterpolationType.Linear, Action onFinish = null)
        {
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            Quaternion startingRot = objectToMove.transform.rotation;

            // perform interpolation
            while (elapsedTime < seconds)
            {
                float lerpDelta = elapsedTime / seconds;
                objectToMove.transform.position = Interpolation.Interpolate(startingPos, endPos, lerpDelta, interpolationType);
                objectToMove.transform.rotation = Interpolation.Interpolate(startingRot, endRot, lerpDelta, interpolationType);
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            objectToMove.transform.position = endPos;
            objectToMove.transform.rotation = endRot;

            onFinish?.Invoke();
        }

        public static IEnumerator MoveAndRotateByCenterOverSeconds(GameObject objectToMove, Vector3 center, Vector3 endPos, Quaternion endRot, float seconds, InterpolationType interpolationType = InterpolationType.Linear, Action onFinish = null)
        {
            Transform objTransform = objectToMove.transform;
	        float elapsedTime = 0;
	        Vector3 centerToPivotLocal = objTransform.InverseTransformVector(objTransform.position - center);
	        Quaternion startingRot = objTransform.rotation;

	        // perform interpolation
	        while (elapsedTime < seconds)
	        {
		        float lerpDelta = elapsedTime / seconds;
		        Vector3 currentCenterPos = Interpolation.Interpolate(center, endPos, lerpDelta, interpolationType);
                objTransform.position = currentCenterPos + objTransform.TransformVector(centerToPivotLocal);

                objTransform.rotation = Interpolation.Interpolate(startingRot, endRot, lerpDelta, interpolationType);
		        elapsedTime += Time.deltaTime;
		        yield return new WaitForEndOfFrame();
	        }

            objTransform.position = endPos + objTransform.TransformVector(centerToPivotLocal);
            objTransform.rotation = endRot;

	        onFinish?.Invoke();
        }

        /// <summary>
        /// Interpolate color of a UI component and all of its child Graphics to
        /// a given alpha.
        /// </summary>
        public static IEnumerator FadeUI(RectTransform rootObject, float duration, float finalAlpha, float delay = 0,
            InterpolationType interpolationType = InterpolationType.Linear)
        {
            // store initial alpha values of each child graphic
            Graphic[] graphics = rootObject.GetComponentsInChildren<Graphic>();
            Dictionary<Graphic, float> startAlphas = new Dictionary<Graphic, float>();
            foreach (Graphic graphic in graphics)
            {
                startAlphas.Add(graphic, graphic.color.a);
            }

            // delay fade
            float waitingTimeElapsed = 0;
            while (waitingTimeElapsed < delay)
            {
                waitingTimeElapsed += Time.deltaTime;
                yield return null;
            }

            // perform fade interpolation
            float timeElapsed = 0;
            while (timeElapsed < duration)
            {
                float portion = timeElapsed / duration;
                foreach (Graphic graphic in graphics)
                {
                    graphic.SetAlpha(Interpolation.Interpolate(startAlphas[graphic],
                        finalAlpha, portion, interpolationType));
                }
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // set alphas to their final value
            foreach (Graphic graphic in graphics)
                graphic.SetAlpha(finalAlpha);
        }

        /// <summary>
        /// Perform first coroutine, pause for the specified delay, run second
        /// coroutine.
        /// </summary>
        public static IEnumerator DoXThenY(IEnumerator x, IEnumerator y, float timeBetween = 0)
        {
            yield return x;
            yield return new WaitForSeconds(timeBetween);
            yield return y;
        }
    }
}
