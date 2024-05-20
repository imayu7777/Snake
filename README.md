## 刚体与碰撞器
rigidbody —— 设置碰撞后的反应，提供移动功能 - 设置xx禁用重力、摩擦力等物理属性

collider —— 碰撞检测 - 勾选collider-isTrigger，设置为触发器

>   触发器：
>   * 当一个 Collider 被设置为触发器时，它不会对其他碰撞器引起物理碰撞的影响。
>   * 物理碰撞：根据碰撞器的属性（如 Rigidbody 的质量、速度等）来计算碰撞的反应，通常用于实现物体之间的物理碰撞、反弹、摩擦等物理交互。
>   * 触发器区域内的其他碰撞器可以穿过触发器而不会被阻挡。
>   * 触发器可以检测到其他游戏对象进入或退出它们的区域，并触发 OnTrigger 等触发器事件。


## 关于组件初始化
`GetComponent<>()`      用于从`当前游戏对象`上获取指定类型的组件。

`FindObjectOfType<>()`  会在`整个场景`中搜索该类型的组件，并返回第一个找到的实例。


## 绘制 UI 时
绘制UI时，最好先建立一个 `Canvas`，因为canvas的坐标系和世界坐标系不同，UI 中的组件都使用canvas坐标系。

在这个项目中，我想实现一个计分板，需要一块矩形，两个文本框

一开始我使用了 `2D Object--Sprite--Square`，并为它建立了子物体TMP

然而TMP并没有继承 Square 的位置与大小

正确的做法是：在canvas下建立`UI--Image`，在image下建立TMP

用一个空物体包含这两个TMP，然后为空物体添加水平布局组件，实现对齐

完成后可以删除水平布局组件了


## SetActive and enabled
`SetActive()` 用于控制 GameObject 的激活状态。当一个 GameObject 被禁用时，它的所有组件都会被禁用，不执行任何功能。

`enabled` 用于控制组件的启用状态。当一个组件被禁用时，它不会执行其相关的功能，但其 GameObject 仍然处于激活状态，可以被其他组件或脚本访问。



## 绘制乌萨奇为蛇头：
在 usaqi.png 的 `Sprite Editor` 中，选择 `custom pivot` 调整原点位置，使其与蛇身合理对齐

Snake 的 SpriteRenderer.Order in Layer 设置为 1，使其优先绘制，不会被蛇身遮挡


