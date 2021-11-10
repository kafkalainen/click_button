// TASK: Complete the TODOs in this file to implement the increment and
// decrement buttons. The increment button should increment the number shown in
// the text field, the decerement button should decrement it. Really simple!
//
// The implementation should utilise the Click method. It returns a Task which
// can be awaited. Your implementation should be inside the while loop. It
// should only require a few lines.
//
// The goal of the exercise is to gain familiarity with using C# async/await
// instead of callbacks for handling input. The difficulty of the task varies
// depending on your previous experience with C#. However the amount of code
// required is only a few lines, so you should be able to complete the task in
// 1-2 hours or less.
//
// The Main scene is set up to use this script. Just run it to test the code.
// You don't need to change anything in the scene unless you want to make it
// prettier :)
//
// Once you're done, please send the project back in any way you prefer (by email,
// zipped, github...)
//
// If you have any questions, please reach out!
//
// Good luck!

using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text textCounter;
    public Button buttonIncrement;
    public Button buttonDecrement;

    async void Start()
    {
        int count = 0;

        while (true)
        {
            textCounter.text = count.ToString();
            // TODO: Implement handling button clicks using await. Task.WhenAny should be helpful.
            await Task.WhenAny(Click(buttonDecrement), Click(buttonIncrement));
            count++;
            // TODO: Add a 500ms delay here, just for fun :)
            await Task.Delay(500);
        }
    }

    // NOTE: You shouldn't need to alter this method, but you should utilise it.
    Task<Button> Click(Button button)
    {
        var tcs = new TaskCompletionSource<Button>();
        button.onClick.AddListener(OnClick);
        return tcs.Task;

        void OnClick()
        {
            tcs.SetResult(button);
            button.onClick.RemoveListener(OnClick);
        }
    }
}
