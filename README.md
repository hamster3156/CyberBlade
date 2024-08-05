# CyberBlade

2年生の後期から3年生の前期に作成した3Dアクションゲームです。  

- 制作人数  
3人  

- 担当箇所  
プレイヤー操作の開発を行いました。  

- 実行ファイルは以下の場所にあります  
https://drive.google.com/drive/folders/1psDiANBRokf86vGYxsoggJJT_T5lbm8_?usp=drive_link

- フォルダーの内容について  
AnimationフォルダーにはAnimationに関連するクラスが入っています。  
AnimatorStateMachineフォルダーにはAnimatorのステートで利用したクラスが入っています。  
Commonフォルダーにはエフェクトを削除するクラスが入っています。  
ControllerフォルダーにはAnimatorステートの遷移管理クラスやInputSystemの入力を管理するクラスが入っています。  
Interfaceフォルダーにはダメージやノックバックなどの処理を行うクラスが入っています。  
Managerフォルダーにはプレイヤーの攻撃入力を調整するクラスや画面のカメラ揺れなどのクラスが入っています。  
Physicsフォルダーにはプレイヤーの当たり判定関するクラスが入っています。  
StateMachineフォルダーにはAnimatorステートで管理されていない移動に関する内容のクラスが入っています。  


- 今回のスクリプトについて  
AnimatorStateMachineを利用してゲーム開発を行いました。
![image](https://github.com/user-attachments/assets/c1cf31a6-0e96-44ec-957a-a2e7ca63c92e)
Animatorの状態ごとにクラスを用意することによって、クラスの可読性と拡張性を向上させることができました。
![image](https://github.com/user-attachments/assets/98f52df3-36d3-4ed0-a86c-6a1feaebf6ed)
