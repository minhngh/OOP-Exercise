﻿using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using OOP_Exercise.Utility_Classes;
using System;


namespace OOP_Exercise.Fragments
{

    class FragmentQuiz : Fragment
    {
        TextView txtQuestionContent;
        RadioButton choiceA, choiceB, choiceC, choiceD, choiceE;
        Question question;
        int indexOfQuestion;
        bool isAnswer;
        public event EventHandler RadioChanged;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            isAnswer = false;

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.fragment_question_item, container, false);

            indexOfQuestion = Arguments.GetInt("index", -1);
            question = DataManager.QuestionsList[indexOfQuestion];
            DataManager.AnswersChoosed[indexOfQuestion] = 0;
            FindIdOfWidget(view);
            LoadContent();
            if (DataManager.IsReadResult)
                Validate();

            return view;
        }



        void FindIdOfWidget(View view)
        {
            txtQuestionContent = view.FindViewById<TextView>(Resource.Id.txt_question_content);
            choiceA = view.FindViewById<RadioButton>(Resource.Id.choiceA);
            choiceB = view.FindViewById<RadioButton>(Resource.Id.choiceB);
            choiceC = view.FindViewById<RadioButton>(Resource.Id.choiceC);
            choiceD = view.FindViewById<RadioButton>(Resource.Id.choiceD);
            choiceE = view.FindViewById<RadioButton>(Resource.Id.choiceE);
            choiceA.CheckedChange += ChoiceA_CheckedChange;
            choiceB.CheckedChange += ChoiceB_CheckedChange;
            choiceC.CheckedChange += ChoiceC_CheckedChange;
            choiceD.CheckedChange += ChoiceD_CheckedChange;
            if (DataManager.HasKeyE)
                choiceE.Visibility = ViewStates.Visible;
            else
                choiceE.Visibility = ViewStates.Gone;
            if (choiceE.Visibility == ViewStates.Visible)
            {
                choiceE.CheckedChange += ChoiceE_CheckedChange;
            }
        }

        void LoadContent()
        {
            txtQuestionContent.Text = question.QuestionText;
            choiceA.Text = question.AnswerA;
            choiceB.Text = question.AnswerB;
            choiceC.Text = question.AnswerC;
            choiceD.Text = question.AnswerD;
            choiceE.Text = question.AnswerE;

        }

        private void ChoiceE_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                DataManager.AnswersChoosed[indexOfQuestion] = 5;
                DataManager.CurrQuesList[indexOfQuestion].IsAnswered = true;
                if (!isAnswer)
                {
                    ++DataManager.NumOfQuesAnswered;
                    isAnswer = true;
                }
                RadioChanged?.Invoke(null, null);


            }
        }

        private void ChoiceD_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if ((sender as RadioButton).Checked)
                DataManager.AnswersChoosed[indexOfQuestion] = 4;
            DataManager.CurrQuesList[indexOfQuestion].IsAnswered = true;
            if (!isAnswer)
            {
                ++DataManager.NumOfQuesAnswered;
                isAnswer = true;
            }
            RadioChanged?.Invoke(null, null);

        }

        private void ChoiceC_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if ((sender as RadioButton).Checked)
                DataManager.AnswersChoosed[indexOfQuestion] = 3;
            DataManager.CurrQuesList[indexOfQuestion].IsAnswered = true;
            if (!isAnswer)
            {
                ++DataManager.NumOfQuesAnswered;
                isAnswer = true;
            }
            RadioChanged?.Invoke(null, null);

        }

        private void ChoiceB_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if ((sender as RadioButton).Checked)
                DataManager.AnswersChoosed[indexOfQuestion] = 2;
            DataManager.CurrQuesList[indexOfQuestion].IsAnswered = true;
            if (!isAnswer)
            {
                ++DataManager.NumOfQuesAnswered;
                isAnswer = true;
            }
            RadioChanged?.Invoke(null, null);

        }

        private void ChoiceA_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if ((sender as RadioButton).Checked)
                DataManager.AnswersChoosed[indexOfQuestion] = 1;
            DataManager.CurrQuesList[indexOfQuestion].IsAnswered = true;
            if (!isAnswer)
            {
                ++DataManager.NumOfQuesAnswered;
                isAnswer = true;
            }
            RadioChanged?.Invoke(null, null);

        }

        public byte GetAnswerChoosed()
        {
            return DataManager.AnswersChoosed[indexOfQuestion];
        }

        public void Validate()
        {
            if (choiceA == null || choiceB == null || choiceC == null || choiceD == null)
                return;
            choiceA.Enabled = choiceB.Enabled = choiceC.Enabled = choiceD.Enabled = false;
            if (DataManager.HasKeyE)
                choiceE.Enabled = false;
            byte rightKey = DataManager.QuestionsList[indexOfQuestion].CorrectAnswer;
            this.Activity.RunOnUiThread(() =>
            {
                switch (rightKey)
                {
                    case 1:
                        choiceA.SetTextColor(Android.Graphics.Color.LightGreen);
                        break;
                    case 2:
                        choiceB.SetTextColor(Android.Graphics.Color.LightGreen);
                        break;
                    case 3:
                        choiceC.SetTextColor(Android.Graphics.Color.LightGreen);
                        break;
                    case 4:
                        choiceD.SetTextColor(Android.Graphics.Color.LightGreen);
                        break;
                    case 5:
                        choiceE.SetTextColor(Android.Graphics.Color.LightGreen);
                        break;
                }
            });
            byte keyOfUser = DataManager.AnswersChoosed[indexOfQuestion];
            if (keyOfUser == rightKey)
                return;
        }
    }
}