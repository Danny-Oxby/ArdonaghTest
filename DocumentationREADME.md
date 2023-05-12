# ArdonaghTest

As a final step, please add no more than single page of documentation to cover off the following
information:
1. Design decisions taken
2. Any issues found
3. What would be your next steps to further improve your work?

1.	The first design decision was to use WPF rather than alternative frameworks. Despite having not used WPF before this was selected due to my experience with similar front end languages the experience of which was used as a base for development. The second decision  was the use of MVVM for development, this allowed proper code separation, such as validation being separated from the view model and model stage, and allowed the code to be used in multiple places. The final decision was to use a popup for the add and edit page, this was chosen as it allowed the “When the user presses Edit the same customer details dialog/page should appear with the details of the customer that is currently selected in the list or grid.” Requirement to be more easily implemented. 

2.	One issue was found during the manual testing stage of development, this is for the height input the save button’s state doesn’t properly update relative to the value in the box, for example when creating a user if all 3 other inputs are valid the save button is active if the user then puts an invalid input into height there is a period of time, before the focus is lost on the box, when the user can press the save button. Doing this will enter the last valid input or 0 is there was none, thereby incorrectly informing the user.

3.	The next development step would be to improve the user interface of the application such as; adding scroll functionality to the customer table so that the user can access a larger number of users, creating a custom popup using a new window so that it can be moved and has common window functions including the top right exit button, and including a CSS file to add consisting styling to UI elements such as buttons and grids. Secondly I would expand the created unit tests to cover the view model methods ,as well as the current validation method. 
