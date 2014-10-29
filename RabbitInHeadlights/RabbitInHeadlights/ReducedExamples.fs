module ReducedExamples
    type Key = {key : string}
    type KeyboardInput = 
        member this.KeyPressed (key:Key) =
            if key.key = "Left" then 
                true
            else
                false
(*
    let (|LeftKey|RightKey|OtherKey|) (keyboard:KeyboardInput) = 
        if keyboard.KeyPressed(Key.Left) then LeftKey
        elif keyboard.KeyPressed(Key.Right) then RightKey
        else OtherKey "Hi, you pressed a key...well that is interesting :D"
            
    
    let (|RightSoemthing|) (keyboard:KeyboardInput) = 
        keyboard.KeyPressed(Key.Right), "Test from right something" 

    let (|LeftSoemthing|) (keyboard:KeyboardInput) = 
        keyboard.KeyPressed(Key.Left)
    
    interface ICmpUpdatable with
        member this.OnUpdate()=        
            match DualityApp.Keyboard with
            //| LeftSoemthing true & RightSoemthing (wasPressed, stringy) -> () //the left and not the right
            | LeftKey  -> 
                let leftWall = Scene.Current.FindGameObject("LeftWall")
                if leftWall.Transform.Pos.X + HalfWidth leftWall.RigidBody <= this.GameObj.Transform.Pos.X - HalfWidth this.GameObj.RigidBody  then
                    this.GameObj.Transform.MoveBy(-Vector2.UnitX * 10.0f)                  
            | RightKey->
                 let rightWall = Scene.Current.FindGameObject("RightWall")
                 if (this.GameObj.Transform.Pos.X + HalfWidth this.GameObj.RigidBody <= rightWall.Transform.Pos.X - HalfWidth rightWall.RigidBody) then
               //if (rightWall.Transform.Pos.X - HalfWidth rightWall.RigidBody > this.GameObj.Transform.Pos.X + HalfWidth this.GameObj.RigidBody ) then
                    this.GameObj.Transform.MoveBy(Vector2.UnitX * 10.0f)
            | OtherKey s-> ()

            *)