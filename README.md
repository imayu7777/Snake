rigidbody —— 设置碰撞后的反应，提供移动功能 - 设置xx禁用重力、摩擦力等物理属性

collider —— 碰撞检测 - 勾选collider-isTrigger，设置为触发器

>   触发器：
>   * 当一个 Collider 被设置为触发器时，它不会对其他碰撞器引起物理碰撞的影响。
>   * 物理碰撞：根据碰撞器的属性（如 Rigidbody 的质量、速度等）来计算碰撞的反应，通常用于实现物体之间的物理碰撞、反弹、摩擦等物理交互。
>   * 触发器区域内的其他碰撞器可以穿过触发器而不会被阻挡。
>   * 触发器可以检测到其他游戏对象进入或退出它们的区域，并触发 OnTrigger 等触发器事件。

`GetComponent<>()`      用于从`当前游戏对象`上获取指定类型的组件。
`FindObjectOfType<>()`  会在`整个场景`中搜索该类型的组件，并返回第一个找到的实例。