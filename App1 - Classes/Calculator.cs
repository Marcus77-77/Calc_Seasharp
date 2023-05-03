
using System;
using App1Classes.Enumerators;

namespace App1Classes
{
    public class Calculator
    {
        private int _memory = 0;
        public int Memory => _memory;

        private char[] _chars = 
            {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '=' };

        private const int _totNumbers = 10;

        private EnumInputState _inputState = EnumInputState.WaitForNumber;
        private EnumOperator _lastOperator = EnumOperator.Addition;

        private bool _done = false;

        public bool Done { get => _done; }

        public bool ParseInput(string text)
        {
            int textLength = text.Length;

            for (int i = 0; i < textLength; i++)
            {
                char c = text[i];
                bool isInArray = false;

                for (int k = 0; k < _chars.Length; k++)
                {
                    if (c == _chars[k])
                    {
                        isInArray = true;
                        break;
                    }
                }

                if (isInArray == false)
                {
                    return false;
                }
            }

            return true;
        }

        public void ExecuteOperation(string text)
        {

            System.Diagnostics.Debug.WriteLine(text);
            System.Diagnostics.Debug.WriteLine(_memory);
            System.Diagnostics.Debug.WriteLine(_inputState);
            System.Diagnostics.Debug.WriteLine(_lastOperator);

            if (_inputState == EnumInputState.WaitForNumber)
            {
                //Operazioni richieste quando legge un numero
                if (checkNumber(text))
                {
                    int localNumber = Convert.ToInt32(text);

                    switch (_lastOperator)
                    {
                        case EnumOperator.Addition:
                            _memory += localNumber;
                            break;
                        case EnumOperator.Subtraction:
                            _memory -= localNumber;
                            break;
                        case EnumOperator.Multiplication:
                            _memory *= localNumber;
                            break;
                        case EnumOperator.Division:
                            _memory /= localNumber;
                            break;
                        default:
                            break;
                    }
                    _inputState = EnumInputState.WaitForOperator;
                }
            }
            else
            {
                //Operazioni richieste quando legge un operatore
                if (checkOperator(text))
                {
                    switch (text)
                    {
                        case "+":
                            _lastOperator = EnumOperator.Addition;
                            break;
                        case "-":
                            _lastOperator = EnumOperator.Subtraction;
                            break;
                        case "/":
                            _lastOperator = EnumOperator.Division;
                            break;
                        case "*":
                            _lastOperator = EnumOperator.Multiplication;
                            break;
                        case "=":
                            _done= true;
                            break;
                        default:
                            break;
                    }
                    _inputState = EnumInputState.WaitForNumber;
                }
            }
        }




        private bool checkNumber(string text)
        {
            foreach (char c in text)
            {
                int index = (int)c - 48;

                if (index < 0 || index >= _totNumbers)
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkOperator(string text)
        {
            if (text.Length != 1)
            {
                return false;
            }
            char c = text[0];
            int index = (int)c - 48;

            if (index >= 0 && index < _totNumbers)
            {
                return false;
            }
            return true;
        }
    }
}
