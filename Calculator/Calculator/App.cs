using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber
{
    class App
    {
        readonly IAnimation animation;
        readonly IGame game;

        public App(IAnimation animation, IGame game)
        {
            this.animation = animation;
            this.game = game;
        }

        public void Run()
        {


    }

}