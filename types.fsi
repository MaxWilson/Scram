

namespace Fable.Import
  module PIXI = begin
    type RendererType =
      interface
        abstract member CANVAS : float
        abstract member UNKNOWN : float
        abstract member WEBGL : float
      end
    type BlendModes =
      interface
        abstract member ADD : float
        abstract member COLOR : float
        abstract member COLOR_BURN : float
        abstract member COLOR_DODGE : float
        abstract member DARKEN : float
        abstract member DIFFERENCE : float
        abstract member EXCLUSION : float
        abstract member HARD_LIGHT : float
        abstract member HUE : float
        abstract member LIGHTEN : float
        abstract member LUMINOSITY : float
        abstract member MULTIPLY : float
        abstract member NORMAL : float
        abstract member OVERLAY : float
        abstract member SATURATION : float
        abstract member SCREEN : float
        abstract member SOFT_LIGHT : float
      end
    type DrawModes =
      interface
        abstract member LINES : float
        abstract member LINE_LOOP : float
        abstract member LINE_STRIP : float
        abstract member POINTS : float
        abstract member TRIANGLES : float
        abstract member TRIANGLE_FAN : float
        abstract member TRIANGLE_STRIP : float
      end
    type ScaleModes =
      interface
        abstract member DEFAULT : float
        abstract member LINEAR : float
        abstract member NEAREST : float
      end
    type DefaultRenderOptions =
      interface
        abstract member antialias : bool
        abstract member autoResize : bool
        abstract member backgroundColor : float
        abstract member clearBeforeRender : bool
        abstract member forceFXAA : bool
        abstract member preserveDrawingBuffer : bool
        abstract member resolution : float
        abstract member roundPixels : bool
        abstract member transparent : bool
        abstract member view : Browser.HTMLCanvasElement
      end
    type Shapes =
      interface
        abstract member CIRC : float
        abstract member ELIP : float
        abstract member POLY : float
        abstract member RECT : float
        abstract member RREC : float
      end
    type InteractionEvent =
      interface
        abstract member data : obj
        abstract member stopped : bool
        abstract member target : obj
        abstract member type : string
        abstract member data : obj with set
        abstract member stopped : bool with set
        abstract member target : obj with set
        abstract member type : string with set
        abstract member stopPropagation : unit -> unit
      end
    [<Core.ImportAttribute ("EventEmitter", "pixi.js")>]
    type EventEmitter =
      class
        new : unit -> EventEmitter
        member
          addListener : event:string * fn:JS.Function * ?context:obj ->
                          EventEmitter
        member emit : event:string * [<System.ParamArray>] args:obj [] -> bool
        member listeners : event:string -> ResizeArray<JS.Function>
        member
          off : event:string * ?fn:JS.Function * ?context:obj * ?once:bool ->
                  EventEmitter
        member on : event:string * fn:JS.Function * ?context:obj -> EventEmitter
        member
          once : event:string * fn:JS.Function * ?context:obj -> EventEmitter
        member removeAllListeners : ?event:string -> EventEmitter
        member
          removeListener : event:string * ?fn:JS.Function * ?context:obj *
                           ?once:bool -> EventEmitter
      end
    [<Core.ImportAttribute ("DisplayObject", "pixi.js")>]
    and DisplayObject =
      class
        inherit EventEmitter
        new : unit -> DisplayObject
        member _cacheAsBitmapDestroy : unit -> unit
        member _destroyCachedDisplayObject : unit -> unit
        member _getCachedBounds : unit -> Rectangle
        member _initCachedDisplayObject : renderer:WebGLRenderer -> unit
        member _initCachedDisplayObjectCanvas : renderer:CanvasRenderer -> unit
        member _renderCachedCanvas : renderer:CanvasRenderer -> unit
        member _renderCachedWebGL : renderer:WebGLRenderer -> unit
        member destroy : unit -> unit
        member
          generateTexture : renderer:Core.U2<CanvasRenderer,WebGLRenderer> *
                            scaleMode:float * resolution:float -> Texture
        member getBounds : ?matrix:Matrix -> Rectangle
        member getChildByName : name:string -> DisplayObject
        member getGlobalPosition : point:Point -> Point
        member getLocalBounds : unit -> Rectangle
        member _bounds : Rectangle
        member _cachedObject : obj
        member _cachedSprite : obj
        member _cr : float
        member _currentBounds : Rectangle
        member _mask : Rectangle
        member _originalDestroy : obj
        member _originalHitTest : obj
        member _originalRenderCanvas : CanvasRenderer
        member _originalRenderWebGL : WebGLRenderer
        member _originalUpdateTransform : bool
        member _sr : float
        member alpha : float
        member buttonMode : bool
        member cacheAsBitmap : bool
        member defaultCursor : string
        member filterArea : Rectangle
        member filters : ResizeArray<AbstractFilter> option
        member hitArea : HitArea
        member interactive : bool
        member interactiveChildren : bool
        member mask : Core.U2<Graphics,Sprite> option
        member name : string
        member parent : Container
        member pivot : Point
        member position : Point
        member renderable : bool
        member rotation : float
        member scale : Point
        member visible : bool
        member worldAlpha : float
        member worldTransform : Matrix
        member worldVisible : bool
        member x : float
        member y : float
        member on : event:string * fn:JS.Function * ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.on('click',$1...)")>]
        member
          on_click : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                       EventEmitter
        [<Core.EmitAttribute ("$0.on('mouseclick',$1...)")>]
        member
          on_mouseclick : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                            EventEmitter
        [<Core.EmitAttribute ("$0.on('mousedown',$1...)")>]
        member
          on_mousedown : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                           EventEmitter
        [<Core.EmitAttribute ("$0.on('mouseout',$1...)")>]
        member
          on_mouseout : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                          EventEmitter
        [<Core.EmitAttribute ("$0.on('mouseover',$1...)")>]
        member
          on_mouseover : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                           EventEmitter
        [<Core.EmitAttribute ("$0.on('mouseup',$1...)")>]
        member
          on_mouseup : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                         EventEmitter
        [<Core.EmitAttribute ("$0.on('mouseupoutside',$1...)")>]
        member
          on_mouseupoutside : fn:System.Func<InteractionEvent,unit> *
                              ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.on('rightclick',$1...)")>]
        member
          on_rightclick : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                            EventEmitter
        [<Core.EmitAttribute ("$0.on('rightdown',$1...)")>]
        member
          on_rightdown : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                           EventEmitter
        [<Core.EmitAttribute ("$0.on('rightup',$1...)")>]
        member
          on_rightup : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                         EventEmitter
        [<Core.EmitAttribute ("$0.on('rightupoutside',$1...)")>]
        member
          on_rightupoutside : fn:System.Func<InteractionEvent,unit> *
                              ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.on('tap',$1...)")>]
        member
          on_tap : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                     EventEmitter
        [<Core.EmitAttribute ("$0.on('touchend',$1...)")>]
        member
          on_touchend : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                          EventEmitter
        [<Core.EmitAttribute ("$0.on('touchendoutside',$1...)")>]
        member
          on_touchendoutside : fn:System.Func<InteractionEvent,unit> *
                               ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.on('touchmove',$1...)")>]
        member
          on_touchmove : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                           EventEmitter
        [<Core.EmitAttribute ("$0.on('touchstart',$1...)")>]
        member
          on_touchstart : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                            EventEmitter
        member
          once : event:string * fn:JS.Function * ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.once('click',$1...)")>]
        member
          once_click : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                         EventEmitter
        [<Core.EmitAttribute ("$0.once('mouseclick',$1...)")>]
        member
          once_mouseclick : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                              EventEmitter
        [<Core.EmitAttribute ("$0.once('mousedown',$1...)")>]
        member
          once_mousedown : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                             EventEmitter
        [<Core.EmitAttribute ("$0.once('mouseout',$1...)")>]
        member
          once_mouseout : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                            EventEmitter
        [<Core.EmitAttribute ("$0.once('mouseover',$1...)")>]
        member
          once_mouseover : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                             EventEmitter
        [<Core.EmitAttribute ("$0.once('mouseup',$1...)")>]
        member
          once_mouseup : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                           EventEmitter
        [<Core.EmitAttribute ("$0.once('mouseupoutside',$1...)")>]
        member
          once_mouseupoutside : fn:System.Func<InteractionEvent,unit> *
                                ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.once('rightclick',$1...)")>]
        member
          once_rightclick : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                              EventEmitter
        [<Core.EmitAttribute ("$0.once('rightdown',$1...)")>]
        member
          once_rightdown : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                             EventEmitter
        [<Core.EmitAttribute ("$0.once('rightup',$1...)")>]
        member
          once_rightup : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                           EventEmitter
        [<Core.EmitAttribute ("$0.once('rightupoutside',$1...)")>]
        member
          once_rightupoutside : fn:System.Func<InteractionEvent,unit> *
                                ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.once('tap',$1...)")>]
        member
          once_tap : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                       EventEmitter
        [<Core.EmitAttribute ("$0.once('touchend',$1...)")>]
        member
          once_touchend : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                            EventEmitter
        [<Core.EmitAttribute ("$0.once('touchendoutside',$1...)")>]
        member
          once_touchendoutside : fn:System.Func<InteractionEvent,unit> *
                                 ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.once('touchmove',$1...)")>]
        member
          once_touchmove : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                             EventEmitter
        [<Core.EmitAttribute ("$0.once('touchstart',$1...)")>]
        member
          once_touchstart : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                              EventEmitter
        member setParent : container:Container -> Container
        member
          setTransform : ?x:float * ?y:float * ?scaleX:float * ?scaleY:float *
                         ?rotation:float * ?skewX:float * ?skewY:float *
                         ?pivotX:float * ?pivotY:float -> DisplayObject
        member _bounds : Rectangle with set
        member _cachedObject : obj with set
        member _cachedSprite : obj with set
        member _cr : float with set
        member _currentBounds : Rectangle with set
        member _mask : Rectangle with set
        member _originalDestroy : obj with set
        member _originalHitTest : obj with set
        member _originalRenderCanvas : CanvasRenderer with set
        member _originalRenderWebGL : WebGLRenderer with set
        member _originalUpdateTransform : bool with set
        member _sr : float with set
        member alpha : float with set
        member buttonMode : bool with set
        member cacheAsBitmap : bool with set
        member defaultCursor : string with set
        member filterArea : Rectangle with set
        member filters : ResizeArray<AbstractFilter> option with set
        member hitArea : HitArea with set
        member interactive : bool with set
        member interactiveChildren : bool with set
        member mask : Core.U2<Graphics,Sprite> option with set
        member name : string with set
        member parent : Container with set
        member pivot : Point with set
        member position : Point with set
        member renderable : bool with set
        member rotation : float with set
        member scale : Point with set
        member visible : bool with set
        member worldAlpha : float with set
        member worldTransform : Matrix with set
        member worldVisible : bool with set
        member x : float with set
        member y : float with set
        member toGlobal : position:Point -> Point
        member toLocal : position:Point * ?from:DisplayObject -> Point
        member updateTransform : unit -> unit
      end
    [<Core.ImportAttribute ("Container", "pixi.js")>]
    and Container =
      class
        inherit DisplayObject
        new : unit -> Container
        member _renderCanvas : renderer:CanvasRenderer -> unit
        member _renderWebGL : renderer:WebGLRenderer -> unit
        member
          addChild : [<System.ParamArray>] child:DisplayObject [] ->
                       DisplayObject
        member addChildAt : child:DisplayObject * index:float -> DisplayObject
        member destroy : ?destroyChildren:bool -> unit
        member
          generateTexture : renderer:Core.U2<CanvasRenderer,WebGLRenderer> *
                            ?resolution:float * ?scaleMode:float -> Texture
        member getChildAt : index:float -> DisplayObject
        member getChildIndex : child:DisplayObject -> float
        member children : ResizeArray<DisplayObject>
        member height : float
        member onChildrenChange : System.Func<unit>
        member width : float
        member on : event:string * fn:JS.Function * ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.on('added',$1...)")>]
        member
          on_added : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                       EventEmitter
        [<Core.EmitAttribute ("$0.on('removed',$1...)")>]
        member
          on_removed : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                         EventEmitter
        member
          once : event:string * fn:JS.Function * ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.once('added',$1...)")>]
        member
          once_added : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                         EventEmitter
        [<Core.EmitAttribute ("$0.once('removed',$1...)")>]
        member
          once_removed : fn:System.Func<InteractionEvent,unit> * ?context:obj ->
                           EventEmitter
        member removeChild : child:DisplayObject -> DisplayObject
        member removeChildAt : index:float -> DisplayObject
        member
          removeChildren : ?beginIndex:float * ?endIndex:float ->
                             ResizeArray<DisplayObject>
        member renderCanvas : renderer:CanvasRenderer -> unit
        member renderWebGL : renderer:WebGLRenderer -> unit
        member setChildIndex : child:DisplayObject * index:float -> unit
        member children : ResizeArray<DisplayObject> with set
        member height : float with set
        member onChildrenChange : System.Func<unit> with set
        member width : float with set
        member swapChildren : child:DisplayObject * child2:DisplayObject -> unit
      end
    [<Core.ImportAttribute ("GraphicsData", "pixi.js")>]
    and GraphicsData =
      class
        new : lineWidth:float * lineColor:float * lineAlpha:float *
              fillColor:float * fillAlpha:float * fill:bool *
              shape:Core.U4<Circle,Rectangle,Ellipse,Polygon> -> GraphicsData
        member clone : unit -> GraphicsData
        member _fillTint : float
        member _lineTint : float
        member fill : bool
        member fillAlpha : float
        member fillColor : float
        member lineAlpha : float
        member lineColor : float
        member lineWidth : float
        member shape : Core.U4<Circle,Rectangle,Ellipse,Polygon>
        member type : float
        member _fillTint : float with set
        member _lineTint : float with set
        member fill : bool with set
        member fillAlpha : float with set
        member fillColor : float with set
        member lineAlpha : float with set
        member lineColor : float with set
        member lineWidth : float with set
        member shape : Core.U4<Circle,Rectangle,Ellipse,Polygon> with set
        member type : float with set
      end
    [<Core.ImportAttribute ("Graphics", "pixi.js")>]
    and Graphics =
      class
        inherit Container
        new : unit -> Graphics
        member
          arc : cx:float * cy:float * radius:float * startAngle:float *
                endAngle:float * ?anticlockwise:bool -> Graphics
        member
          arcTo : x1:float * y1:float * x2:float * y2:float * radius:float ->
                    Graphics
        member beginFill : color:float * ?alpha:float -> Graphics
        member
          bezierCurveTo : cpX:float * cpY:float * cpX2:float * cpY2:float *
                          toX:float * toY:float -> Graphics
        member clear : unit -> Graphics
        member clone : unit -> Graphics
        member containsPoint : point:Point -> bool
        member drawCircle : x:float * y:float * radius:float -> Graphics
        member
          drawEllipse : x:float * y:float * width:float * height:float ->
                          Graphics
        member
          drawPolygon : path:Core.U2<ResizeArray<float>,ResizeArray<Point>> ->
                          Graphics
        member
          drawRect : x:float * y:float * width:float * height:float -> Graphics
        member
          drawRoundedRect : x:float * y:float * width:float * height:float *
                            radius:float -> Graphics
        member
          drawShape : shape:Core.U4<Circle,Rectangle,Ellipse,Polygon> ->
                        GraphicsData
        member endFill : unit -> Graphics
        member
          generateTexture : renderer:Core.U2<WebGLRenderer,CanvasRenderer> *
                            ?resolution:float * ?scaleMode:float -> Texture
        member getBounds : ?matrix:Matrix -> Rectangle
        member blendMode : float
        member boundsDirty : bool
        member boundsPadding : float
        member dirty : bool
        member fillAlpha : float
        member glDirty : bool
        member isMask : bool
        member lineColor : float
        member lineWidth : float
        member tint : float
        member
          lineStyle : ?lineWidth:float * ?color:float * ?alpha:float -> Graphics
        member lineTo : x:float * y:float -> Graphics
        member moveTo : x:float * y:float -> Graphics
        member
          quadraticCurveTo : cpX:float * cpY:float * toX:float * toY:float ->
                               Graphics
        member blendMode : float with set
        member boundsDirty : bool with set
        member boundsPadding : float with set
        member dirty : bool with set
        member fillAlpha : float with set
        member glDirty : bool with set
        member isMask : bool with set
        member lineColor : float with set
        member lineWidth : float with set
        member tint : float with set
        member updateLocalBounds : unit -> unit
      end
    and GraphicsRenderer =
      interface
        abstract member flush : unit -> unit
        abstract member render : ?object:obj -> unit
        abstract member start : unit -> unit
        abstract member stop : unit -> unit
      end
    and WebGLGraphicsData
    [<Core.ImportAttribute ("Point", "pixi.js")>]
    and Point =
      class
        new : ?x:float * ?y:float -> Point
        member clone : unit -> Point
        member copy : p:Point -> unit
        member equals : p:Point -> bool
        member x : float
        member y : float
        member set : ?x:float * ?y:float -> unit
        member x : float with set
        member y : float with set
      end
    [<Core.ImportAttribute ("Matrix", "pixi.js")>]
    and Matrix =
      class
        new : unit -> Matrix
        member append : matrix:Matrix -> Matrix
        member apply : pos:Point * ?newPos:Point -> Point
        member applyInverse : pos:Point * ?newPos:Point -> Point
        member clone : unit -> Matrix
        member copy : matrix:Matrix -> Matrix
        member fromArray : array:ResizeArray<float> -> unit
        member IDENTITY : Matrix
        member TEMP_MATRIX : Matrix
        member a : float
        member b : float
        member c : float
        member d : float
        member tx : float
        member ty : float
        member identity : unit -> Matrix
        member invert : unit -> Matrix
        member prepend : matrix:Matrix -> Matrix
        member rotate : angle:float -> Matrix
        member scale : x:float * y:float -> Matrix
        member
          set : a:float * b:float * c:float * d:float * tx:float * ty:float ->
                  Matrix
        member
          setTransform : a:float * b:float * c:float * d:float * sr:float *
                         cr:float * cy:float * sy:float * nsx:float * cs:float ->
                           Matrix
        member IDENTITY : Matrix with set
        member TEMP_MATRIX : Matrix with set
        member a : float with set
        member b : float with set
        member c : float with set
        member d : float with set
        member tx : float with set
        member ty : float with set
        member
          toArray : ?transpose:bool * ?out:ResizeArray<float> ->
                      ResizeArray<float>
        member translate : x:float * y:float -> Matrix
      end
    and HitArea =
      interface
        abstract member contains : x:float * y:float -> bool
      end
    [<Core.ImportAttribute ("Circle", "pixi.js")>]
    and Circle =
      class
        interface HitArea
        new : ?x:float * ?y:float * ?radius:float -> Circle
        member clone : unit -> Circle
        member getBounds : unit -> Rectangle
        member radius : float
        member type : float
        member x : float
        member y : float
        member radius : float with set
        member type : float with set
        member x : float with set
        member y : float with set
      end
    [<Core.ImportAttribute ("Ellipse", "pixi.js")>]
    and Ellipse =
      class
        interface HitArea
        new : ?x:float * ?y:float * ?width:float * ?height:float -> Ellipse
        member clone : unit -> Ellipse
        member getBounds : unit -> Rectangle
        member height : float
        member type : float
        member width : float
        member x : float
        member y : float
        member height : float with set
        member type : float with set
        member width : float with set
        member x : float with set
        member y : float with set
      end
    [<Core.ImportAttribute ("Polygon", "pixi.js")>]
    and Polygon =
      class
        interface HitArea
        new : [<System.ParamArray>] points:float [] -> Polygon
        member clone : unit -> Polygon
        member closed : bool
        member points : ResizeArray<float>
        member type : float
        member closed : bool with set
        member points : ResizeArray<float> with set
        member type : float with set
      end
    [<Core.ImportAttribute ("Rectangle", "pixi.js")>]
    and Rectangle =
      class
        interface HitArea
        new : ?x:float * ?y:float * ?width:float * ?height:float -> Rectangle
        member clone : unit -> Rectangle
        member EMPTY : Rectangle
        member height : float
        member type : float
        member width : float
        member x : float
        member y : float
        member EMPTY : Rectangle with set
        member height : float with set
        member type : float with set
        member width : float with set
        member x : float with set
        member y : float with set
      end
    [<Core.ImportAttribute ("RoundedRectangle", "pixi.js")>]
    and RoundedRectangle =
      class
        interface HitArea
        new : ?x:float * ?y:float * ?width:float * ?height:float * ?radius:float ->
                RoundedRectangle
        member clone : unit -> Rectangle
        member EMPTY : Rectangle
        member height : float
        member radius : float
        member type : float
        member width : float
        member x : float
        member y : float
        member EMPTY : Rectangle with set
        member height : float with set
        member radius : float with set
        member type : float with set
        member width : float with set
        member x : float with set
        member y : float with set
      end
    [<Core.KeyValueListAttribute ()>]
    and ParticleContainerProperties =
      | Scale of bool
      | Position of bool
      | Rotation of bool
      | Uvs of bool
      | Alpha of bool
    [<Core.ImportAttribute ("ParticleContainer", "pixi.js")>]
    and ParticleContainer =
      class
        inherit Container
        new : ?size:float * ?properties:ParticleContainerProperties list *
              ?batchSize:float -> ParticleContainer
        member _batchSize : float
        member _bufferToUpdate : float
        member _buffers : ResizeArray<Browser.WebGLBuffer>
        member _maxSize : float
        member _properties : ResizeArray<bool>
        member blendMode : float
        member interactiveChildren : bool
        member onChildrenChange : System.Func<float,unit>
        member roundPixels : bool
        member
          setProperties : properties:ParticleContainerProperties list -> unit
        member _batchSize : float with set
        member _bufferToUpdate : float with set
        member _buffers : ResizeArray<Browser.WebGLBuffer> with set
        member _maxSize : float with set
        member _properties : ResizeArray<bool> with set
        member blendMode : float with set
        member interactiveChildren : bool with set
        member onChildrenChange : System.Func<float,unit> with set
        member roundPixels : bool with set
      end
    and ParticleBuffer =
      interface
        abstract member bind : unit -> unit
        abstract member destroy : unit -> unit
        abstract member dynamicBuffer : obj
        abstract member dynamicData : obj
        abstract member dynamicProperties : ResizeArray<obj>
        abstract member dynamicStride : float
        abstract member gl : Browser.WebGLRenderingContext
        abstract member size : float
        abstract member staticBuffer : obj
        abstract member staticData : obj
        abstract member staticProperties : ResizeArray<obj>
        abstract member staticStride : float
        abstract member vertByteSize : float
        abstract member vertSize : float
        abstract member initBuffers : unit -> unit
        abstract member dynamicBuffer : obj with set
        abstract member dynamicData : obj with set
        abstract member dynamicProperties : ResizeArray<obj> with set
        abstract member dynamicStride : float with set
        abstract member gl : Browser.WebGLRenderingContext with set
        abstract member size : float with set
        abstract member staticBuffer : obj with set
        abstract member staticData : obj with set
        abstract member staticProperties : ResizeArray<obj> with set
        abstract member staticStride : float with set
        abstract member vertByteSize : float with set
        abstract member vertSize : float with set
      end
    and ParticleRenderer
    and ParticleShader
    [<Core.KeyValueListAttribute ()>]
    and RendererOptions =
      | View of Browser.HTMLCanvasElement
      | Transparent of bool
      | Antialias of bool
      | AutoResize of bool
      | Resolution of float
      | ClearBeforeRendering of bool
      | PreserveDrawingBuffer of bool
      | ForceFXAA of bool
      | RoundPixels of bool
      | BackgroundColor of float
    [<Core.ImportAttribute ("SystemRenderer", "pixi.js")>]
    and SystemRenderer =
      class
        inherit EventEmitter
        new : system:string * ?width:float * ?height:float *
              ?options:RendererOptions list -> SystemRenderer
        member destroy : ?removeView:bool -> unit
        member _backgroundColor : float
        member _backgroundColorRgb : ResizeArray<float>
        member _backgroundColorString : string
        member _lastObjectRendered : DisplayObject
        member _tempDisplayObjectParent : obj
        member autoResize : bool
        member backgroundColor : float
        member blendModes : obj
        member clearBeforeRender : bool
        member height : float
        member preserveDrawingBuffer : bool
        member resolution : float
        member roundPixels : bool
        member transparent : bool
        member type : float
        member view : Browser.HTMLCanvasElement
        member width : float
        member render : object:DisplayObject -> unit
        member resize : width:float * height:float -> unit
        member _backgroundColor : float with set
        member _backgroundColorRgb : ResizeArray<float> with set
        member _backgroundColorString : string with set
        member _lastObjectRendered : DisplayObject with set
        member _tempDisplayObjectParent : obj with set
        member autoResize : bool with set
        member backgroundColor : float with set
        member blendModes : obj with set
        member clearBeforeRender : bool with set
        member height : float with set
        member preserveDrawingBuffer : bool with set
        member resolution : float with set
        member roundPixels : bool with set
        member transparent : bool with set
        member type : float with set
        member view : Browser.HTMLCanvasElement with set
        member width : float with set
      end
    [<Core.ImportAttribute ("CanvasRenderer", "pixi.js")>]
    and CanvasRenderer =
      class
        inherit SystemRenderer
        new : ?width:float * ?height:float * ?options:RendererOptions list ->
                CanvasRenderer
        member _mapBlendModes : unit -> unit
        member context : Browser.CanvasRenderingContext2D
        member maskManager : CanvasMaskManager
        member refresh : bool
        member roundPixels : bool
        member smoothProperty : string
        member render : object:DisplayObject -> unit
        member
          renderDisplayObject : displayObject:DisplayObject *
                                context:Browser.CanvasRenderingContext2D -> unit
        member resize : w:float * h:float -> unit
        member context : Browser.CanvasRenderingContext2D with set
        member maskManager : CanvasMaskManager with set
        member refresh : bool with set
        member roundPixels : bool with set
        member smoothProperty : string with set
      end
    [<Core.ImportAttribute ("CanvasBuffer", "pixi.js")>]
    and CanvasBuffer =
      class
        new : width:float * height:float -> CanvasBuffer
        member clear : unit -> unit
        member destroy : unit -> unit
        member canvas : Browser.HTMLCanvasElement
        member context : Browser.CanvasRenderingContext2D
        member height : float
        member width : float
        member resize : width:float * height:float -> unit
        member canvas : Browser.HTMLCanvasElement with set
        member context : Browser.CanvasRenderingContext2D with set
        member height : float with set
        member width : float with set
      end
    [<Core.ImportAttribute ("CanvasGraphics", "pixi.js")>]
    and CanvasGraphics =
      class
        new : unit -> CanvasGraphics
        static member
          renderGraphics : graphics:Graphics *
                           context:Browser.CanvasRenderingContext2D -> unit
        static member
          renderGraphicsMask : graphics:Graphics *
                               context:Browser.CanvasRenderingContext2D -> unit
        static member updateGraphicsTint : graphics:Graphics -> unit
      end
    [<Core.ImportAttribute ("CanvasMaskManager", "pixi.js")>]
    and CanvasMaskManager =
      class
        new : unit -> CanvasMaskManager
        member destroy : unit -> unit
        member popMask : renderer:Core.U2<WebGLRenderer,CanvasRenderer> -> unit
        member
          pushMask : maskData:obj *
                     renderer:Core.U2<WebGLRenderer,CanvasRenderer> -> unit
      end
    [<Core.ImportAttribute ("CanvasTinter", "pixi.js")>]
    and CanvasTinter =
      class
        new : unit -> CanvasTinter
        member cacheStepsPerColorChannel : float
        member convertTintToImage : bool
        member tintMethod : JS.Function
        member vanUseMultiply : bool
        member cacheStepsPerColorChannel : float with set
        member convertTintToImage : bool with set
        member tintMethod : JS.Function with set
        member vanUseMultiply : bool with set
        static member
          getTintedTexture : sprite:DisplayObject * color:float ->
                               Browser.HTMLCanvasElement
        static member roundColor : color:float -> float
        static member
          tintWithMultiply : texture:Texture * color:float *
                             canvas:Browser.HTMLDivElement -> unit
        static member
          tintWithOverlay : texture:Texture * color:float *
                            canvas:Browser.HTMLCanvasElement -> unit
        static member
          tintWithPerPixel : texture:Texture * color:float *
                             canvas:Browser.HTMLCanvasElement -> unit
      end
    [<Core.ImportAttribute ("WebGLRenderer", "pixi.js")>]
    and WebGLRenderer =
      class
        inherit SystemRenderer
        new : ?width:float * ?height:float * ?options:RendererOptions list ->
                WebGLRenderer
        member _createContext : unit -> unit
        member _initContext : unit -> unit
        member _mapGlModes : unit -> unit
        member
          destroyTexture : texture:Core.U2<BaseTexture,Texture> *
                           ?_skipRemove:bool -> unit
        member _FXAAFilter : obj
        member _contextOptions : obj
        member _managedTextures : ResizeArray<Texture>
        member _renderTargetStack : ResizeArray<RenderTarget>
        member _useFXAA : bool
        member blendModeManager : BlendModeManager
        member currentRenderTarget : RenderTarget
        member currentRenderer : ObjectRenderer
        member drawCount : float
        member filterManager : FilterManager
        member handleContextLost : System.Func<Browser.WebGLContextEvent,unit>
        member maskManager : MaskManager
        member shaderManager : ShaderManager
        member stencilManager : StencilManager
        member render : object:DisplayObject -> unit
        member
          renderDisplayObject : displayObject:DisplayObject *
                                renderTarget:RenderTarget * clear:bool -> unit
        member setObjectRenderer : objectRenderer:ObjectRenderer -> unit
        member setRenderTarget : renderTarget:RenderTarget -> unit
        member _FXAAFilter : obj with set
        member _contextOptions : obj with set
        member _managedTextures : ResizeArray<Texture> with set
        member _renderTargetStack : ResizeArray<RenderTarget> with set
        member _useFXAA : bool with set
        member blendModeManager : BlendModeManager with set
        member currentRenderTarget : RenderTarget with set
        member currentRenderer : ObjectRenderer with set
        member drawCount : float with set
        member filterManager : FilterManager with set
        member
          handleContextLost : System.Func<Browser.WebGLContextEvent,unit>
                                with set
        member maskManager : MaskManager with set
        member shaderManager : ShaderManager with set
        member stencilManager : StencilManager with set
        member
          updateTexture : texture:Core.U2<BaseTexture,Texture> ->
                            Core.U2<BaseTexture,Texture>
      end
    [<Core.ImportAttribute ("AbstractFilter", "pixi.js")>]
    and AbstractFilter =
      class
        new : ?vertexSrc:Core.U2<string,ResizeArray<string>> *
              ?fragmentSrc:Core.U2<string,ResizeArray<string>> * ?uniforms:obj ->
                AbstractFilter
        member
          applyFilter : renderer:WebGLRenderer * input:RenderTarget *
                        output:RenderTarget * ?clear:bool -> unit
        member getShader : renderer:WebGLRenderer -> Shader
        member fragmentSrc : ResizeArray<string>
        member padding : float
        member uniforms : obj
        member vertexSrc : ResizeArray<string>
        member fragmentSrc : ResizeArray<string> with set
        member padding : float with set
        member uniforms : obj with set
        member vertexSrc : ResizeArray<string> with set
        member syncUniform : uniform:Browser.WebGLUniformLocation -> unit
      end
    [<Core.ImportAttribute ("SpriteMaskFilter", "pixi.js")>]
    and SpriteMaskFilter =
      class
        inherit AbstractFilter
        new : sprite:Sprite -> SpriteMaskFilter
        member
          applyFilter : renderer:Browser.WebGLRenderbuffer * input:RenderTarget *
                        output:RenderTarget -> unit
        member map : Texture
        member maskMatrix : Matrix
        member maskSprite : Sprite
        member offset : Point
        member map : Texture with set
        member maskMatrix : Matrix with set
        member maskSprite : Sprite with set
        member offset : Point with set
      end
    [<Core.ImportAttribute ("BlendModeManager", "pixi.js")>]
    and BlendModeManager =
      class
        inherit WebGLManager
        new : renderer:WebGLRenderer -> BlendModeManager
        member setBlendMode : blendMode:float -> bool
      end
    [<Core.ImportAttribute ("FilterManager", "pixi.js")>]
    and FilterManager =
      class
        inherit WebGLManager
        new : renderer:WebGLRenderer -> FilterManager
        member
          applyFilter : shader:Core.U2<Shader,AbstractFilter> *
                        inputTarget:RenderTarget * outputTarget:RenderTarget *
                        ?clear:bool -> unit
        member
          calculateMappedMatrix : filterArea:Rectangle * sprite:Sprite *
                                  ?outputMatrix:Matrix -> Matrix
        member capFilterArea : filterArea:Rectangle -> unit
        member destroy : unit -> unit
        member getRenderTarget : ?clear:bool -> RenderTarget
        member filterStack : ResizeArray<obj>
        member onContextChange : System.Func<unit>
        member renderer : WebGLRenderer
        member texturePool : ResizeArray<obj>
        member popFilter : unit -> AbstractFilter
        member
          pushFilter : target:RenderTarget * filters:ResizeArray<obj> -> unit
        member resize : width:float * height:float -> unit
        member returnRenderTarget : renderTarget:RenderTarget -> unit
        member setFilterStack : filterStack:ResizeArray<obj> -> unit
        member filterStack : ResizeArray<obj> with set
        member onContextChange : System.Func<unit> with set
        member renderer : WebGLRenderer with set
        member texturePool : ResizeArray<obj> with set
      end
    [<Core.ImportAttribute ("MaskManager", "pixi.js")>]
    and MaskManager =
      class
        inherit WebGLManager
        new : unit -> MaskManager
        member alphaMaskPool : ResizeArray<obj>
        member count : float
        member reverse : bool
        member stencilStack : StencilMaskStack
        member popMask : target:RenderTarget * maskData:obj -> unit
        member popSpriteMask : unit -> unit
        member popStencilMask : target:RenderTarget * maskData:obj -> unit
        member pushMask : target:RenderTarget * maskData:obj -> unit
        member pushSpriteMask : target:RenderTarget * maskData:obj -> unit
        member pushStencilMask : target:RenderTarget * maskData:obj -> unit
        member alphaMaskPool : ResizeArray<obj> with set
        member count : float with set
        member reverse : bool with set
        member stencilStack : StencilMaskStack with set
      end
    [<Core.ImportAttribute ("ShaderManager", "pixi.js")>]
    and ShaderManager =
      class
        inherit WebGLManager
        new : renderer:WebGLRenderer -> ShaderManager
        member destroy : unit -> unit
        member _currentId : float
        member attribState : ResizeArray<obj>
        member currentShader : Shader
        member maxAttibs : float
        member stack : ResizeArray<obj>
        member tempAttribState : ResizeArray<obj>
        member setAttribs : attribs:ResizeArray<obj> -> unit
        member setShader : shader:Shader -> bool
        member _currentId : float with set
        member attribState : ResizeArray<obj> with set
        member currentShader : Shader with set
        member maxAttibs : float with set
        member stack : ResizeArray<obj> with set
        member tempAttribState : ResizeArray<obj> with set
      end
    [<Core.ImportAttribute ("StencilManager", "pixi.js")>]
    and StencilManager =
      class
        inherit WebGLManager
        new : renderer:WebGLRenderer -> StencilManager
        member
          bindGraphics : graphics:Graphics * webGLData:WebGLGraphicsData -> unit
        member destroy : unit -> unit
        member popMask : maskData:ResizeArray<obj> -> unit
        member
          popStencil : graphics:Graphics * webGLData:WebGLGraphicsData -> unit
        member pushMask : maskData:ResizeArray<obj> -> unit
        member
          pushStencil : graphics:Graphics * webGLData:WebGLGraphicsData -> unit
        member setMaskStack : stencilMaskStack:StencilMaskStack -> unit
      end
    [<Core.ImportAttribute ("WebGLManager", "pixi.js")>]
    and WebGLManager =
      class
        new : renderer:WebGLRenderer -> WebGLManager
        member destroy : unit -> unit
        member onContextChange : System.Func<unit>
        member renderer : WebGLRenderer
        member onContextChange : System.Func<unit> with set
        member renderer : WebGLRenderer with set
      end
    [<Core.ImportAttribute ("Shader", "pixi.js")>]
    and Shader =
      class
        new : shaderManager:ShaderManager * vertexSrc:string *
              fragmentSrc:string * uniforms:obj * attributes:obj -> Shader
        member _glCompile : type:obj * src:obj -> Shader
        member cacheAttributeLocations : keys:ResizeArray<string> -> unit
        member cacheUniformLocations : keys:ResizeArray<string> -> unit
        member compile : unit -> Browser.WebGLProgram
        member destroy : unit -> unit
        member attributes : obj
        member fragmentSrc : string
        member gl : Browser.WebGLRenderingContext
        member program : Browser.WebGLProgram
        member shaderManager : ShaderManager
        member textureCount : float
        member uniforms : obj
        member uuid : float
        member vertexSrc : string
        member init : unit -> unit
        member initSampler2D : uniform:obj -> unit
        member attributes : obj with set
        member fragmentSrc : string with set
        member gl : Browser.WebGLRenderingContext with set
        member program : Browser.WebGLProgram with set
        member shaderManager : ShaderManager with set
        member textureCount : float with set
        member uniforms : obj with set
        member uuid : float with set
        member vertexSrc : string with set
        member syncUniform : uniform:obj -> unit
        member syncUniforms : unit -> unit
      end
    [<Core.ImportAttribute ("ComplexPrimitiveShader", "pixi.js")>]
    and ComplexPrimitiveShader =
      class
        inherit Shader
        new : shaderManager:ShaderManager -> ComplexPrimitiveShader
      end
    [<Core.ImportAttribute ("PrimitiveShader", "pixi.js")>]
    and PrimitiveShader =
      class
        inherit Shader
        new : shaderManager:ShaderManager -> PrimitiveShader
      end
    [<Core.ImportAttribute ("TextureShader", "pixi.js")>]
    and TextureShader =
      class
        inherit Shader
        new : shaderManager:ShaderManager * ?vertexSrc:string *
              ?fragmentSrc:string * ?customUniforms:obj * ?customAttributes:obj ->
                TextureShader
      end
    and StencilMaskStack =
      interface
        abstract member count : float
        abstract member reverse : bool
        abstract member stencilStack : ResizeArray<obj>
        abstract member count : float with set
        abstract member reverse : bool with set
        abstract member stencilStack : ResizeArray<obj> with set
      end
    [<Core.ImportAttribute ("ObjectRenderer", "pixi.js")>]
    and ObjectRenderer =
      class
        inherit WebGLManager
        new : unit -> ObjectRenderer
        member flush : unit -> unit
        member render : ?object:obj -> unit
        member start : unit -> unit
        member stop : unit -> unit
      end
    [<Core.ImportAttribute ("RenderTarget", "pixi.js")>]
    and RenderTarget =
      class
        new : gl:Browser.WebGLRenderingContext * width:float * height:float *
              scaleMode:float * resolution:float * root:bool -> RenderTarget
        member activate : unit -> unit
        member attachStencilBuffer : unit -> unit
        member calculateProjection : protectionFrame:Matrix -> unit
        member clear : ?bind:bool -> unit
        member destroy : unit -> unit
        member filterStack : ResizeArray<obj>
        member frame : Rectangle
        member frameBuffer : Browser.WebGLFramebuffer
        member gl : Browser.WebGLRenderingContext
        member projectionMatrix : Matrix
        member resolution : float
        member root : bool
        member scaleMode : float
        member size : Rectangle
        member stencilBuffer : Browser.WebGLRenderbuffer
        member stencilMaskStack : StencilMaskStack
        member texture : Texture
        member transform : Matrix
        member resize : width:float * height:float -> unit
        member filterStack : ResizeArray<obj> with set
        member frame : Rectangle with set
        member frameBuffer : Browser.WebGLFramebuffer with set
        member gl : Browser.WebGLRenderingContext with set
        member projectionMatrix : Matrix with set
        member resolution : float with set
        member root : bool with set
        member scaleMode : float with set
        member size : Rectangle with set
        member stencilBuffer : Browser.WebGLRenderbuffer with set
        member stencilMaskStack : StencilMaskStack with set
        member texture : Texture with set
        member transform : Matrix with set
      end
    and Quad =
      interface
        abstract member destroy : unit -> unit
        abstract member colors : ResizeArray<float>
        abstract member gl : Browser.WebGLRenderingContext
        abstract member indexBuffer : Browser.WebGLBuffer
        abstract member indices : ResizeArray<float>
        abstract member uvs : ResizeArray<float>
        abstract member vertexBuffer : Browser.WebGLBuffer
        abstract member vertices : ResizeArray<float>
        abstract member map : rect:Rectangle * rect2:Rectangle -> unit
        abstract member colors : ResizeArray<float> with set
        abstract member gl : Browser.WebGLRenderingContext with set
        abstract member indexBuffer : Browser.WebGLBuffer with set
        abstract member indices : ResizeArray<float> with set
        abstract member uvs : ResizeArray<float> with set
        abstract member vertexBuffer : Browser.WebGLBuffer with set
        abstract member vertices : ResizeArray<float> with set
        abstract member upload : unit -> unit
      end
    [<Core.ImportAttribute ("Sprite", "pixi.js")>]
    and Sprite =
      class
        inherit Container
        new : ?texture:Texture -> Sprite
        member _onTextureUpdate : unit -> unit
        member containsPoint : point:Point -> bool
        member destroy : ?destroyTexture:bool * ?destroyBaseTexture:bool -> unit
        member getBounds : ?matrix:Matrix -> Rectangle
        member getLocalBounds : unit -> Rectangle
        member _height : float
        member _texture : Texture
        member _width : float
        member anchor : Point
        member blendMode : float
        member cachedTint : float
        member height : float
        member shader : Core.U2<Shader,AbstractFilter>
        member texture : Texture
        member tint : float
        member width : float
        member _height : float with set
        member _texture : Texture with set
        member _width : float with set
        member anchor : Point with set
        member blendMode : float with set
        member cachedTint : float with set
        member height : float with set
        member shader : Core.U2<Shader,AbstractFilter> with set
        member texture : Texture with set
        member tint : float with set
        member width : float with set
        static member fromFrame : frameId:string -> Sprite
        static member
          fromImage : imageId:string * ?crossorigin:bool * ?scaleMode:float ->
                        Sprite
      end
    [<Core.ImportAttribute ("SpriteRenderer", "pixi.js")>]
    and SpriteRenderer =
      class
        inherit ObjectRenderer
        new : unit -> SpriteRenderer
        member destroy : unit -> unit
        member flush : unit -> unit
        member colors : ResizeArray<float>
        member currentBatchSize : float
        member indices : ResizeArray<float>
        member positions : ResizeArray<float>
        member shader : Core.U2<Shader,AbstractFilter>
        member size : float
        member sprites : ResizeArray<Sprite>
        member vertByteSize : float
        member vertSize : float
        member vertices : ResizeArray<float>
        member render : sprite:Sprite -> unit
        member
          renderBatch : texture:Texture * size:float * startIndex:float -> unit
        member colors : ResizeArray<float> with set
        member currentBatchSize : float with set
        member indices : ResizeArray<float> with set
        member positions : ResizeArray<float> with set
        member shader : Core.U2<Shader,AbstractFilter> with set
        member size : float with set
        member sprites : ResizeArray<Sprite> with set
        member vertByteSize : float with set
        member vertSize : float with set
        member vertices : ResizeArray<float> with set
        member start : unit -> unit
      end
    [<Core.KeyValueListAttribute ()>]
    and TextStyle =
      | Font of string
      | Fill of Core.U2<string,float>
      | Align of string
      | Stroke of Core.U2<string,float>
      | StrokeThickness of float
      | WordWrap of bool
      | WordWrapWidth of float
      | LineHeight of float
      | DropShadow of bool
      | DropShadowColor of Core.U2<string,float>
      | DropShadowAngle of float
      | DropShadowDistance of float
      | Padding of float
      | TextBaseline of string
      | LineJoin of string
      | MiterLimit of float
    [<Core.ImportAttribute ("Text", "pixi.js")>]
    and Text =
      class
        inherit Sprite
        new : ?text:string * ?style:TextStyle list * ?resolution:float -> Text
        member
          determineFontProperties : fontStyle:TextStyle list -> TextStyle list
        member _style : TextStyle list
        member _text : string
        member canvas : Browser.HTMLCanvasElement
        member context : Browser.CanvasRenderingContext2D
        member dirty : bool
        member fontPropertiesCache : obj
        member fontPropertiesCanvas : Browser.HTMLCanvasElement
        member fontPropertiesContext : Browser.CanvasRenderingContext2D
        member height : float
        member resolution : float
        member style : TextStyle list
        member text : string
        member width : float
        member _style : TextStyle list with set
        member _text : string with set
        member canvas : Browser.HTMLCanvasElement with set
        member context : Browser.CanvasRenderingContext2D with set
        member dirty : bool with set
        member fontPropertiesCache : obj with set
        member fontPropertiesCanvas : Browser.HTMLCanvasElement with set
        member fontPropertiesContext : Browser.CanvasRenderingContext2D with set
        member height : float with set
        member resolution : float with set
        member style : TextStyle list with set
        member text : string with set
        member width : float with set
        member updateText : unit -> unit
        member updateTexture : unit -> unit
        member wordWrap : text:string -> bool
      end
    [<Core.ImportAttribute ("BaseTexture", "pixi.js")>]
    and BaseTexture =
      class
        inherit EventEmitter
        new : source:Core.U2<Browser.HTMLImageElement,Browser.HTMLCanvasElement> *
              ?scaleMode:float * ?resolution:float -> BaseTexture
        member _sourceLoaded : unit -> unit
        member destroy : unit -> unit
        member dispose : unit -> unit
        member _glTextures : obj
        member hasLoaded : bool
        member height : float
        member imageUrl : string
        member isLoading : bool
        member isPowerOfTwo : bool
        member mipmap : bool
        member premultipliedAlpha : bool
        member realHeight : float
        member realWidth : float
        member resolution : float
        member scaleMode : float
        member
          source : Core.U3<Browser.HTMLImageElement,Browser.HTMLCanvasElement,
                           Browser.HTMLVideoElement>
        member uuid : float
        member width : float
        member
          loadSource : source:Core.U2<Browser.HTMLImageElement,
                                      Browser.HTMLCanvasElement> -> unit
        member on : event:string * fn:JS.Function * ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.on('dispose',$1...)")>]
        member
          on_dispose : fn:System.Func<BaseTexture,unit> * ?context:obj ->
                         EventEmitter
        [<Core.EmitAttribute ("$0.on('error',$1...)")>]
        member
          on_error : fn:System.Func<BaseTexture,unit> * ?context:obj ->
                       EventEmitter
        [<Core.EmitAttribute ("$0.on('loaded',$1...)")>]
        member
          on_loaded : fn:System.Func<BaseTexture,unit> * ?context:obj ->
                        EventEmitter
        [<Core.EmitAttribute ("$0.on('update',$1...)")>]
        member
          on_update : fn:System.Func<BaseTexture,unit> * ?context:obj ->
                        EventEmitter
        member
          once : event:string * fn:JS.Function * ?context:obj -> EventEmitter
        [<Core.EmitAttribute ("$0.once('dispose',$1...)")>]
        member
          once_dispose : fn:System.Func<BaseTexture,unit> * ?context:obj ->
                           EventEmitter
        [<Core.EmitAttribute ("$0.once('error',$1...)")>]
        member
          once_error : fn:System.Func<BaseTexture,unit> * ?context:obj ->
                         EventEmitter
        [<Core.EmitAttribute ("$0.once('loaded',$1...)")>]
        member
          once_loaded : fn:System.Func<BaseTexture,unit> * ?context:obj ->
                          EventEmitter
        [<Core.EmitAttribute ("$0.once('update',$1...)")>]
        member
          once_update : fn:System.Func<BaseTexture,unit> * ?context:obj ->
                          EventEmitter
        member _glTextures : obj with set
        member hasLoaded : bool with set
        member height : float with set
        member imageUrl : string with set
        member isLoading : bool with set
        member isPowerOfTwo : bool with set
        member mipmap : bool with set
        member premultipliedAlpha : bool with set
        member realHeight : float with set
        member realWidth : float with set
        member resolution : float with set
        member scaleMode : float with set
        member
          source : Core.U3<Browser.HTMLImageElement,Browser.HTMLCanvasElement,
                           Browser.HTMLVideoElement> with set
        member uuid : float with set
        member width : float with set
        member update : unit -> unit
        member updateSourceImage : newSrc:string -> unit
        static member
          fromCanvas : canvas:Browser.HTMLCanvasElement * ?scaleMode:float ->
                         BaseTexture
        static member
          fromImage : imageUrl:string * ?crossorigin:bool * ?scaleMode:float ->
                        BaseTexture
      end
    [<Core.ImportAttribute ("RenderTexture", "pixi.js")>]
    and RenderTexture =
      class
        inherit Texture
        new : renderer:Core.U2<CanvasRenderer,WebGLRenderer> * ?width:float *
              ?height:float * ?scaleMode:float * ?resolution:float ->
                RenderTexture
        member clear : unit -> unit
        member destroy : unit -> unit
        member getBase64 : unit -> string
        member getCanvas : unit -> Browser.HTMLCanvasElement
        member getImage : unit -> Browser.HTMLImageElement
        member getPixel : x:float * y:float -> ResizeArray<float>
        member getPixels : unit -> ResizeArray<float>
        member height : float
        member renderer : Core.U2<CanvasRenderer,WebGLRenderer>
        member resolution : float
        member valid : bool
        member width : float
        member
          render : displayObject:DisplayObject * ?matrix:Matrix * ?clear:bool *
                   ?updateTransform:bool -> unit
        member
          renderCanvas : displayObject:DisplayObject * ?matrix:Matrix *
                         ?clear:bool * ?updateTransform:bool -> unit
        member
          renderWebGL : displayObject:DisplayObject * ?matrix:Matrix *
                        ?clear:bool * ?updateTransform:bool -> unit
        member resize : width:float * height:float * ?updateBase:bool -> unit
        member height : float with set
        member renderer : Core.U2<CanvasRenderer,WebGLRenderer> with set
        member resolution : float with set
        member valid : bool with set
        member width : float with set
      end
    [<Core.ImportAttribute ("Texture", "pixi.js")>]
    and Texture =
      class
        inherit BaseTexture
        new : baseTexture:BaseTexture * ?frame:Rectangle * ?crop:Rectangle *
              ?trim:Rectangle * ?rotate:float -> Texture
        member _updateUvs : unit -> unit
        member clone : unit -> Texture
        member destroy : ?destroyBase:bool -> unit
        member EMPTY : Texture
        member _frame : Rectangle
        member _uvs : TextureUvs
        member baseTexture : BaseTexture
        member crop : Rectangle
        member frame : Rectangle
        member height : float
        member noFrame : bool
        member requiresUpdate : bool
        member rotate : float
        member trim : Rectangle
        member valid : bool
        member width : float
        member onBaseTextureLoaded : baseTexture:BaseTexture -> unit
        member onBaseTextureUpdated : baseTexture:BaseTexture -> unit
        member EMPTY : Texture with set
        member _frame : Rectangle with set
        member _uvs : TextureUvs with set
        member baseTexture : BaseTexture with set
        member crop : Rectangle with set
        member frame : Rectangle with set
        member height : float with set
        member noFrame : bool with set
        member requiresUpdate : bool with set
        member rotate : float with set
        member trim : Rectangle with set
        member valid : bool with set
        member width : float with set
        member update : unit -> unit
        static member addTextureToCache : texture:Texture * id:string -> unit
        static member
          fromCanvas : canvas:Browser.HTMLCanvasElement * ?scaleMode:float ->
                         Texture
        static member fromFrame : frameId:string -> Texture
        static member
          fromImage : imageUrl:string * ?crossOrigin:bool * ?scaleMode:float ->
                        Texture
        static member
          fromVideo : video:Core.U2<Browser.HTMLVideoElement,string> *
                      ?scaleMode:float -> Texture
        static member
          fromVideoUrl : videoUrl:string * ?scaleMode:float -> Texture
        static member removeTextureFromCache : id:string -> Texture
      end
    [<Core.ImportAttribute ("TextureUvs", "pixi.js")>]
    and TextureUvs =
      class
        new : unit -> TextureUvs
        member x0 : float
        member x1 : float
        member x2 : float
        member x3 : float
        member y0 : float
        member y1 : float
        member y2 : float
        member y3 : float
        member set : frame:Rectangle * baseFrame:Rectangle * rotate:bool -> unit
        member x0 : float with set
        member x1 : float with set
        member x2 : float with set
        member x3 : float with set
        member y0 : float with set
        member y1 : float with set
        member y2 : float with set
        member y3 : float with set
      end
    [<Core.ImportAttribute ("VideoBaseTexture", "pixi.js")>]
    and VideoBaseTexture =
      class
        inherit BaseTexture
        new : source:Browser.HTMLVideoElement * ?scaleMode:float ->
                VideoBaseTexture
        member _onCanPlay : unit -> unit
        member _onPlayStart : unit -> unit
        member _onPlayStop : unit -> unit
        member _onUpdate : unit -> unit
        member destroy : unit -> unit
        member _loaded : bool
        member autoUpdate : bool
        member _loaded : bool with set
        member autoUpdate : bool with set
        static member
          fromUrl : videoSrc:Core.U4<string,obj,ResizeArray<string>,
                                     ResizeArray<obj>> -> VideoBaseTexture
        static member
          fromVideo : video:Browser.HTMLVideoElement * ?scaleMode:float ->
                        VideoBaseTexture
      end
    [<Core.ImportAttribute ("utils", "pixi.js")>]
    and utils =
      class
        new : unit -> utils
        member BaseTextureCache : obj
        member TextureCache : obj
        member BaseTextureCache : obj with set
        member TextureCache : obj with set
        static member canUseNewCanvasBlendModel : unit -> bool
        static member getNextPowerOfTwo : number:float -> float
        static member getResolutionOfUrl : url:string -> float
        static member hex2String : hex:float -> string
        static member
          hex2rgb : hex:float * ?out:ResizeArray<float> -> ResizeArray<float>
        static member isPowerOfTwo : width:float * height:float -> bool
        static member isWebGLSupported : unit -> bool
        static member rgb2hex : rgb:ResizeArray<float> -> float
        static member sayHello : type:string -> unit
        static member sign : n:float -> float
        static member uuid : unit -> float
      end
    [<Core.ImportAttribute ("GroupD8", "pixi.js")>]
    and GroupD8 =
      class
        static member add : rotationSecond:float * rotationFirst:float -> float
        static member byDirection : dx:float * dy:float -> float
        static member E : float
        static member MIRROR_HORIZONTAL : float
        static member MIRROR_VERTICAL : float
        static member N : float
        static member NE : float
        static member NW : float
        static member S : float
        static member SE : float
        static member SW : float
        static member W : float
        static member inv : rotation:float -> float
        static member isSwapWidthHeight : rotation:float -> bool
        static member
          matrixAppendRotationInv : matrix:Matrix * rotation:float * tx:float *
                                    ty:float -> unit
        static member rotate180 : rotation:float -> float
        static member E : float with set
        static member MIRROR_HORIZONTAL : float with set
        static member MIRROR_VERTICAL : float with set
        static member N : float with set
        static member NE : float with set
        static member NW : float with set
        static member S : float with set
        static member SE : float with set
        static member SW : float with set
        static member W : float with set
        static member sub : rotationSecond:float * rotationFirst:float -> float
        static member uX : ind:float -> float
        static member uY : ind:float -> float
        static member vX : ind:float -> float
        static member vY : ind:float -> float
      end
    module extras = begin
      [<Core.KeyValueListAttribute ()>]
      type BitmapTextStyle =
        | Font of Core.U2<string,obj>
        | Align of string
        | Tint of float
      [<Core.ImportAttribute ("extras.BitmapText", "pixi.js")>]
      and BitmapText =
        class
          inherit Container
          new : text:string * ?style:BitmapTextStyle list -> BitmapText
          member _font : Core.U2<string,obj>
          member _glyphs : ResizeArray<Sprite>
          member _text : string
          member align : string
          member dirty : bool
          member font : Core.U2<string,obj>
          member fonts : obj
          member maxLineHeight : float
          member maxWidth : float
          member text : string
          member textHeight : float
          member textWidth : float
          member tint : float
          member _font : Core.U2<string,obj> with set
          member _glyphs : ResizeArray<Sprite> with set
          member _text : string with set
          member align : string with set
          member dirty : bool with set
          member font : Core.U2<string,obj> with set
          member fonts : obj with set
          member maxLineHeight : float with set
          member maxWidth : float with set
          member text : string with set
          member textHeight : float with set
          member textWidth : float with set
          member tint : float with set
          member updateText : unit -> unit
        end
      [<Core.ImportAttribute ("extras.MovieClip", "pixi.js")>]
      and MovieClip =
        class
          inherit Sprite
          new : textures:ResizeArray<Texture> -> MovieClip
          member destroy : unit -> unit
          member _currentTime : float
          member _durations : ResizeArray<float>
          member _textures : ResizeArray<Texture>
          member animationSpeed : float
          member currentFrame : float
          member loop : bool
          member onComplete : System.Func<unit>
          member playing : bool
          member textures : ResizeArray<Texture>
          member totalFrames : float
          member gotoAndPlay : frameName:float -> unit
          member gotoAndStop : frameName:float -> unit
          member play : unit -> unit
          member _currentTime : float with set
          member _durations : ResizeArray<float> with set
          member _textures : ResizeArray<Texture> with set
          member animationSpeed : float with set
          member currentFrame : float with set
          member loop : bool with set
          member onComplete : System.Func<unit> with set
          member playing : bool with set
          member textures : ResizeArray<Texture> with set
          member totalFrames : float with set
          member stop : unit -> unit
          member update : deltaTime:float -> unit
          static member fromFrames : frame:ResizeArray<string> -> MovieClip
          static member fromImages : images:ResizeArray<string> -> MovieClip
        end
      [<Core.ImportAttribute ("extras.TilingSprite", "pixi.js")>]
      and TilingSprite =
        class
          inherit Sprite
          new : texture:Texture * width:float * height:float -> TilingSprite
          member containsPoint : point:Point -> bool
          member destroy : unit -> unit
          member
            generateTilingTexture : renderer:Core.U2<WebGLRenderer,
                                                     CanvasRenderer> *
                                    texture:Texture * ?forcePowerOfTwo:bool ->
                                      Texture
          member getBounds : unit -> Rectangle
          member _refreshTexture : bool
          member _tileScaleOffset : Point
          member _tilingTexture : bool
          member _uvs : ResizeArray<TextureUvs>
          member height : float
          member originalTexture : Texture
          member tilePosition : Point
          member tileScale : Point
          member width : float
          member _refreshTexture : bool with set
          member _tileScaleOffset : Point with set
          member _tilingTexture : bool with set
          member _uvs : ResizeArray<TextureUvs> with set
          member height : float with set
          member originalTexture : Texture with set
          member tilePosition : Point with set
          member tileScale : Point with set
          member width : float with set
          static member fromFrame : frameId:string -> Sprite
          static member
            fromFrame : frameId:string * ?width:float * ?height:float ->
                          TilingSprite
          static member
            fromImage : imageId:string * ?crossorigin:bool * ?scaleMode:float ->
                          Sprite
          static member
            fromImage : imageId:string * ?width:float * ?height:float *
                        ?crossorigin:bool * ?scaleMode:float -> TilingSprite
        end
    end
    module filters = begin
      [<Core.ImportAttribute ("filters.AsciiFilter", "pixi.js")>]
      type AsciiFilter =
        class
          inherit AbstractFilter
          new : unit -> AsciiFilter
          member size : float
          member size : float with set
        end
      [<Core.ImportAttribute ("filters.BloomFilter", "pixi.js")>]
      and BloomFilter =
        class
          inherit AbstractFilter
          new : unit -> BloomFilter
          member blur : float
          member blurX : float
          member blurY : float
          member blur : float with set
          member blurX : float with set
          member blurY : float with set
        end
      [<Core.ImportAttribute ("filters.BlurFilter", "pixi.js")>]
      and BlurFilter =
        class
          inherit AbstractFilter
          new : unit -> BlurFilter
          member blur : float
          member blurX : float
          member blurXFilter : BlurXFilter
          member blurY : float
          member blurYFilter : BlurYFilter
          member passes : float
          member blur : float with set
          member blurX : float with set
          member blurXFilter : BlurXFilter with set
          member blurY : float with set
          member blurYFilter : BlurYFilter with set
          member passes : float with set
        end
      [<Core.ImportAttribute ("filters.BlurXFilter", "pixi.js")>]
      and BlurXFilter =
        class
          inherit AbstractFilter
          new : unit -> BlurXFilter
          member blur : float
          member passes : float
          member strength : float
          member blur : float with set
          member passes : float with set
          member strength : float with set
        end
      [<Core.ImportAttribute ("filters.BlurYFilter", "pixi.js")>]
      and BlurYFilter =
        class
          inherit AbstractFilter
          new : unit -> BlurYFilter
          member blur : float
          member passes : float
          member strength : float
          member blur : float with set
          member passes : float with set
          member strength : float with set
        end
      [<Core.ImportAttribute ("filters.SmartBlurFilter", "pixi.js")>]
      and SmartBlurFilter =
        class
          inherit AbstractFilter
          new : unit -> SmartBlurFilter
        end
      [<Core.ImportAttribute ("filters.ColorMatrixFilter", "pixi.js")>]
      and ColorMatrixFilter =
        class
          inherit AbstractFilter
          new : unit -> ColorMatrixFilter
          member _colorMatrix : matrix:ResizeArray<float> -> unit
          member _loadMatrix : matrix:ResizeArray<float> * multiply:bool -> unit
          member
            _multiply : out:ResizeArray<float> * a:ResizeArray<float> *
                        b:ResizeArray<float> -> unit
          member blackAndWhite : ?multiply:bool -> unit
          member brightness : b:float * ?multiply:bool -> unit
          member browni : ?multiply:bool -> unit
          member
            colorTone : desaturation:float * toned:float * lightColor:string *
                        darkColor:string * ?multiply:bool -> unit
          member contrast : amount:float * ?multiply:bool -> unit
          member desaturate : ?multiply:bool -> unit
          member matrix : ResizeArray<float>
          member greyscale : scale:float * ?multiply:bool -> unit
          member hue : rotation:float * ?multiply:bool -> unit
          member kodachrome : ?multiply:bool -> unit
          member lsd : ?multiply:bool -> unit
          member negative : ?multiply:bool -> unit
          member night : intensity:float * ?multiply:bool -> unit
          member polaroid : ?multiply:bool -> unit
          member predator : amount:float * ?multiply:bool -> unit
          member reset : unit -> unit
          member saturate : amount:float * ?multiply:bool -> unit
          member sepia : ?multiply:bool -> unit
          member matrix : ResizeArray<float> with set
          member technicolor : ?multiply:bool -> unit
          member toBGR : ?multiply:bool -> unit
          member vintage : ?multiply:bool -> unit
        end
      [<Core.ImportAttribute ("filters.ColorStepFilter", "pixi.js")>]
      and ColorStepFilter =
        class
          inherit AbstractFilter
          new : unit -> ColorStepFilter
          member step : float
          member step : float with set
        end
      [<Core.ImportAttribute ("filters.ConvolutionFilter", "pixi.js")>]
      and ConvolutionFilter =
        class
          inherit AbstractFilter
          new : matrix:ResizeArray<float> * width:float * height:float ->
                  ConvolutionFilter
          member height : float
          member matrix : ResizeArray<float>
          member width : float
          member height : float with set
          member matrix : ResizeArray<float> with set
          member width : float with set
        end
      [<Core.ImportAttribute ("filters.CrossHatchFilter", "pixi.js")>]
      and CrossHatchFilter =
        class
          inherit AbstractFilter
          new : unit -> CrossHatchFilter
        end
      [<Core.ImportAttribute ("filters.DisplacementFilter", "pixi.js")>]
      and DisplacementFilter =
        class
          inherit AbstractFilter
          new : sprite:Sprite * ?scale:float -> DisplacementFilter
          member map : Texture
          member scale : Point
          member map : Texture with set
          member scale : Point with set
        end
      [<Core.ImportAttribute ("filters.DotScreenFilter", "pixi.js")>]
      and DotScreenFilter =
        class
          inherit AbstractFilter
          new : unit -> DotScreenFilter
          member angle : float
          member scale : float
          member angle : float with set
          member scale : float with set
        end
      [<Core.ImportAttribute ("filters.BlurYTintFilter", "pixi.js")>]
      and BlurYTintFilter =
        class
          inherit AbstractFilter
          new : unit -> BlurYTintFilter
          member blur : float
          member blur : float with set
        end
      [<Core.ImportAttribute ("filters.DropShadowFilter", "pixi.js")>]
      and DropShadowFilter =
        class
          inherit AbstractFilter
          new : unit -> DropShadowFilter
          member alpha : float
          member angle : float
          member blur : float
          member blurX : float
          member blurY : float
          member color : float
          member distance : float
          member alpha : float with set
          member angle : float with set
          member blur : float with set
          member blurX : float with set
          member blurY : float with set
          member color : float with set
          member distance : float with set
        end
      [<Core.ImportAttribute ("filters.GrayFilter", "pixi.js")>]
      and GrayFilter =
        class
          inherit AbstractFilter
          new : unit -> GrayFilter
          member gray : float
          member gray : float with set
        end
      [<Core.ImportAttribute ("filters.InvertFilter", "pixi.js")>]
      and InvertFilter =
        class
          inherit AbstractFilter
          new : unit -> InvertFilter
          member invert : float
          member invert : float with set
        end
      [<Core.ImportAttribute ("filters.NoiseFilter", "pixi.js")>]
      and NoiseFilter =
        class
          inherit AbstractFilter
          new : unit -> NoiseFilter
          member noise : float
          member noise : float with set
        end
      [<Core.ImportAttribute ("filters.PixelateFilter", "pixi.js")>]
      and PixelateFilter =
        class
          inherit AbstractFilter
          new : unit -> PixelateFilter
          member size : Point
          member size : Point with set
        end
      [<Core.ImportAttribute ("filters.RGBSplitFilter", "pixi.js")>]
      and RGBSplitFilter =
        class
          inherit AbstractFilter
          new : unit -> RGBSplitFilter
          member blue : float
          member green : float
          member red : float
          member blue : float with set
          member green : float with set
          member red : float with set
        end
      [<Core.ImportAttribute ("filters.SepiaFilter", "pixi.js")>]
      and SepiaFilter =
        class
          inherit AbstractFilter
          new : unit -> SepiaFilter
          member sepia : float
          member sepia : float with set
        end
      [<Core.ImportAttribute ("filters.ShockwaveFilter", "pixi.js")>]
      and ShockwaveFilter =
        class
          inherit AbstractFilter
          new : unit -> ShockwaveFilter
          member center : ResizeArray<float>
          member params : obj
          member time : float
          member center : ResizeArray<float> with set
          member params : obj with set
          member time : float with set
        end
      [<Core.ImportAttribute ("filters.TiltShiftAxisFilter", "pixi.js")>]
      and TiltShiftAxisFilter =
        class
          inherit AbstractFilter
          new : unit -> TiltShiftAxisFilter
          member blur : float
          member end : float
          member gradientBlur : float
          member start : float
          member blur : float with set
          member end : float with set
          member gradientBlur : float with set
          member start : float with set
          member updateDelta : unit -> unit
        end
      [<Core.ImportAttribute ("filters.TiltShiftFilter", "pixi.js")>]
      and TiltShiftFilter =
        class
          inherit AbstractFilter
          new : unit -> TiltShiftFilter
          member blur : float
          member end : float
          member gradientBlur : float
          member start : float
          member blur : float with set
          member end : float with set
          member gradientBlur : float with set
          member start : float with set
        end
      [<Core.ImportAttribute ("filters.TiltShiftXFilter", "pixi.js")>]
      and TiltShiftXFilter =
        class
          inherit AbstractFilter
          new : unit -> TiltShiftXFilter
          member updateDelta : unit -> unit
        end
      [<Core.ImportAttribute ("filters.TiltShiftYFilter", "pixi.js")>]
      and TiltShiftYFilter =
        class
          inherit AbstractFilter
          new : unit -> TiltShiftYFilter
          member updateDelta : unit -> unit
        end
      [<Core.ImportAttribute ("filters.TwistFilter", "pixi.js")>]
      and TwistFilter =
        class
          inherit AbstractFilter
          new : unit -> TwistFilter
          member angle : float
          member offset : Point
          member radius : float
          member angle : float with set
          member offset : Point with set
          member radius : float with set
        end
      [<Core.ImportAttribute ("filters.FXAAFilter", "pixi.js")>]
      and FXAAFilter =
        class
          inherit AbstractFilter
          new : unit -> FXAAFilter
          member
            applyFilter : renderer:WebGLRenderer * input:RenderTarget *
                          output:RenderTarget -> unit
        end
    end
    module interaction = begin
      [<Core.ImportAttribute ("interaction.InteractionData", "pixi.js")>]
      type InteractionData =
        class
          new : unit -> InteractionData
          member
            getLocalPosition : displayObject:DisplayObject * ?point:Point *
                               ?globalPos:Point -> Point
          member global : Point
          member originalEvent : Browser.Event
          member target : DisplayObject
          member global : Point with set
          member originalEvent : Browser.Event with set
          member target : DisplayObject with set
        end
      [<Core.ImportAttribute ("interaction.InteractionManager", "pixi.js")>]
      and InteractionManager =
        class
          new : renderer:Core.U2<CanvasRenderer,WebGLRenderer> * ?options:obj ->
                  InteractionManager
          member addEvents : unit -> unit
          member destroy : unit -> unit
          member
            dispatchEvent : displayObject:DisplayObject * eventString:string *
                            eventData:obj -> unit
          member getTouchData : touchEvent:InteractionData -> InteractionData
          member _tempPoint : Point
          member autoPreventDefault : bool
          member currentCursorStyle : string
          member eventData : obj
          member eventsAdded : bool
          member interactionDOMElement : Browser.HTMLElement
          member interactionFrequency : float
          member interactiveDataPool : ResizeArray<InteractionData>
          member last : float
          member mouse : InteractionData
          member onMouseDown : System.Func<Browser.Event,unit>
          member onMouseMove : System.Func<Browser.Event,unit>
          member onMouseOut : System.Func<Browser.Event,unit>
          member onMouseUp : System.Func<Browser.Event,unit>
          member onTouchEnd : System.Func<Browser.Event,unit>
          member onTouchMove : System.Func<Browser.Event,unit>
          member onTouchStart : System.Func<Browser.Event,unit>
          member processMouseDown : System.Func<DisplayObject,bool,unit>
          member processMouseMove : System.Func<DisplayObject,bool,unit>
          member processMouseOverOut : System.Func<DisplayObject,bool,unit>
          member processMouseUp : System.Func<DisplayObject,bool,unit>
          member processTouchEnd : System.Func<DisplayObject,bool,unit>
          member processTouchMove : System.Func<DisplayObject,bool,unit>
          member processTouchStart : System.Func<DisplayObject,bool,unit>
          member renderer : Core.U2<CanvasRenderer,WebGLRenderer>
          member resolution : float
          member mapPositionToPoint : point:Point * x:float * y:float -> unit
          member
            processInteractive : point:Point * displayObject:DisplayObject *
                                 func:System.Func<DisplayObject,bool,unit> *
                                 hitTest:bool * interactive:bool -> bool
          member removeEvents : unit -> unit
          member returnTouchData : touchData:InteractionData -> unit
          member
            setTargetElement : element:Browser.HTMLElement * resolution:float ->
                                 unit
          member _tempPoint : Point with set
          member autoPreventDefault : bool with set
          member currentCursorStyle : string with set
          member eventData : obj with set
          member eventsAdded : bool with set
          member interactionDOMElement : Browser.HTMLElement with set
          member interactionFrequency : float with set
          member interactiveDataPool : ResizeArray<InteractionData> with set
          member last : float with set
          member mouse : InteractionData with set
          member onMouseDown : System.Func<Browser.Event,unit> with set
          member onMouseMove : System.Func<Browser.Event,unit> with set
          member onMouseOut : System.Func<Browser.Event,unit> with set
          member onMouseUp : System.Func<Browser.Event,unit> with set
          member onTouchEnd : System.Func<Browser.Event,unit> with set
          member onTouchMove : System.Func<Browser.Event,unit> with set
          member onTouchStart : System.Func<Browser.Event,unit> with set
          member
            processMouseDown : System.Func<DisplayObject,bool,unit> with set
          member
            processMouseMove : System.Func<DisplayObject,bool,unit> with set
          member
            processMouseOverOut : System.Func<DisplayObject,bool,unit> with set
          member processMouseUp : System.Func<DisplayObject,bool,unit> with set
          member processTouchEnd : System.Func<DisplayObject,bool,unit> with set
          member
            processTouchMove : System.Func<DisplayObject,bool,unit> with set
          member
            processTouchStart : System.Func<DisplayObject,bool,unit> with set
          member renderer : Core.U2<CanvasRenderer,WebGLRenderer> with set
          member resolution : float with set
          member update : deltaTime:float -> unit
        end
      and InteractiveTarget =
        interface
          abstract member buttonMode : bool
          abstract member defaultCursor : string
          abstract member hitArea : HitArea
          abstract member interactive : bool
          abstract member interactiveChildren : bool
          abstract member buttonMode : bool with set
          abstract member defaultCursor : string with set
          abstract member hitArea : HitArea with set
          abstract member interactive : bool with set
          abstract member interactiveChildren : bool with set
        end
    end
    module loaders = begin
      type LoaderOptions =
        interface
          abstract member crossOrigin : bool option
          abstract member loadType : float option
          abstract member xhrType : string option
          abstract member crossOrigin : bool option with set
          abstract member loadType : float option with set
          abstract member xhrType : string option with set
        end
      and ResourceDictionary =
        interface
          [<Core.EmitAttribute ("$0[$1]{{=$2}}")>]
          abstract member Item : index:string -> Resource with get
          [<Core.EmitAttribute ("$0[$1]{{=$2}}")>]
          abstract member Item : index:string -> Resource with set
        end
      [<Core.ImportAttribute ("loaders.Loader", "pixi.js")>]
      and Loader =
        class
          new : ?baseUrl:string * ?concurrency:float -> Loader
          member
            add : url:string * ?options:LoaderOptions * ?cb:System.Func<unit> ->
                    Loader
          member
            add : obj:obj * ?options:LoaderOptions * ?cb:System.Func<unit> ->
                    Loader
          member
            add : name:string * url:string * ?options:LoaderOptions *
                  ?cb:System.Func<unit> -> Loader
          member after : fn:JS.Function -> Loader
          member before : fn:JS.Function -> Loader
          member baseUrl : string
          member loading : bool
          member progress : float
          member resources : ResourceDictionary
          member load : ?cb:System.Func<Loader,obj,unit> -> Loader
          member
            on : event:string * fn:JS.Function * ?context:obj -> EventEmitter
          [<Core.EmitAttribute ("$0.on('complete',$1...)")>]
          member
            on_complete : fn:System.Func<Loader,obj,unit> * ?context:obj ->
                            EventEmitter
          [<Core.EmitAttribute ("$0.on('error',$1...)")>]
          member
            on_error : fn:System.Func<JS.Error,Loader,Resource,unit> *
                       ?context:obj -> EventEmitter
          [<Core.EmitAttribute ("$0.on('load',$1...)")>]
          member
            on_load : fn:System.Func<Loader,Resource,unit> * ?context:obj ->
                        EventEmitter
          [<Core.EmitAttribute ("$0.on('progress',$1...)")>]
          member
            on_progress : fn:System.Func<Loader,Resource,unit> * ?context:obj ->
                            EventEmitter
          [<Core.EmitAttribute ("$0.on('start',$1...)")>]
          member
            on_start : fn:System.Func<Loader,unit> * ?context:obj ->
                         EventEmitter
          member
            once : event:string * fn:JS.Function * ?context:obj -> EventEmitter
          [<Core.EmitAttribute ("$0.once('complete',$1...)")>]
          member
            once_complete : fn:System.Func<Loader,obj,unit> * ?context:obj ->
                              EventEmitter
          [<Core.EmitAttribute ("$0.once('error',$1...)")>]
          member
            once_error : fn:System.Func<JS.Error,Loader,Resource,unit> *
                         ?context:obj -> EventEmitter
          [<Core.EmitAttribute ("$0.once('load',$1...)")>]
          member
            once_load : fn:System.Func<Loader,Resource,unit> * ?context:obj ->
                          EventEmitter
          [<Core.EmitAttribute ("$0.once('progress',$1...)")>]
          member
            once_progress : fn:System.Func<Loader,Resource,unit> * ?context:obj ->
                              EventEmitter
          [<Core.EmitAttribute ("$0.once('start',$1...)")>]
          member
            once_start : fn:System.Func<Loader,unit> * ?context:obj ->
                           EventEmitter
          member pre : fn:JS.Function -> Loader
          member reset : unit -> unit
          member baseUrl : string with set
          member loading : bool with set
          member progress : float with set
          member resources : ResourceDictionary with set
          member use : fn:JS.Function -> Loader
        end
      [<Core.ImportAttribute ("loaders.Resource", "pixi.js")>]
      and Resource =
        class
          inherit EventEmitter
          new : ?name:string * ?url:Core.U2<string,ResizeArray<string>> *
                ?options:LoaderOptions -> Resource
          member complete : unit -> unit
          member LOAD_TYPE : obj
          member XHR_READ_STATE : obj
          member XHR_RESPONSE_TYPE : obj
          member crossOrigin : string
          member data : obj
          member error : JS.Error
          member loadType : float
          member name : string
          member texture : Texture
          member textures : ResizeArray<Texture>
          member url : string
          member xhr : Browser.XMLHttpRequest
          member xhrType : string
          member load : ?cb:System.Func<unit> -> unit
          member LOAD_TYPE : obj with set
          member XHR_READ_STATE : obj with set
          member XHR_RESPONSE_TYPE : obj with set
          member crossOrigin : string with set
          member data : obj with set
          member error : JS.Error with set
          member loadType : float with set
          member name : string with set
          member texture : Texture with set
          member textures : ResizeArray<Texture> with set
          member url : string with set
          member xhr : Browser.XMLHttpRequest with set
          member xhrType : string with set
        end
    end
    module mesh = begin
      [<Core.ImportAttribute ("mesh.Mesh", "pixi.js")>]
      type Mesh =
        class
          inherit Container
          new : texture:Texture * ?vertices:ResizeArray<float> *
                ?uvs:ResizeArray<float> * ?indices:ResizeArray<float> *
                ?drawMode:float -> Mesh
          member _onTextureUpdate : unit -> unit
          member
            _renderCanvasDrawTriangle : context:Browser.CanvasRenderingContext2D *
                                        vertices:float * uvs:float *
                                        index0:float * index1:float *
                                        index2:float -> unit
          member
            _renderCanvasTriangleMesh : context:Browser.CanvasRenderingContext2D ->
                                          unit
          member
            _renderCanvasTriangles : context:Browser.CanvasRenderingContext2D ->
                                       unit
          member containsPoint : point:Point -> bool
          member getBounds : ?matrix:Matrix -> Rectangle
          member DRAW_MODES : obj
          member _texture : Texture
          member blendMode : float
          member canvasPadding : float
          member dirty : bool
          member drawMode : float
          member indices : ResizeArray<float>
          member shader : Core.U2<Shader,AbstractFilter>
          member texture : Texture
          member uvs : ResizeArray<float>
          member vertices : ResizeArray<float>
          member renderMeshFlat : mesh:Mesh -> unit
          member DRAW_MODES : obj with set
          member _texture : Texture with set
          member blendMode : float with set
          member canvasPadding : float with set
          member dirty : bool with set
          member drawMode : float with set
          member indices : ResizeArray<float> with set
          member shader : Core.U2<Shader,AbstractFilter> with set
          member texture : Texture with set
          member uvs : ResizeArray<float> with set
          member vertices : ResizeArray<float> with set
        end
      [<Core.ImportAttribute ("mesh.Rope", "pixi.js")>]
      and Rope =
        class
          inherit Mesh
          new : texture:Texture * points:ResizeArray<Point> -> Rope
          member getTextureUvs : unit -> TextureUvs
          member _ready : bool
          member colors : ResizeArray<float>
          member points : ResizeArray<Point>
          member refresh : unit -> unit
          member _ready : bool with set
          member colors : ResizeArray<float> with set
          member points : ResizeArray<Point> with set
        end
      [<Core.ImportAttribute ("mesh.Plane", "pixi.js")>]
      and Plane =
        class
          inherit Mesh
          new : texture:Texture * ?segmentsX:float * ?segmentsY:float -> Plane
          member segmentsX : float
          member segmentsY : float
          member segmentsX : float with set
          member segmentsY : float with set
        end
      [<Core.ImportAttribute ("mesh.MeshRenderer", "pixi.js")>]
      and MeshRenderer =
        class
          inherit ObjectRenderer
          new : renderer:WebGLRenderer -> MeshRenderer
          member _initWebGL : mesh:Mesh -> unit
          member destroy : unit -> unit
          member flush : unit -> unit
          member indices : ResizeArray<float>
          member render : mesh:Mesh -> unit
          member indices : ResizeArray<float> with set
          member start : unit -> unit
        end
    end
    module ticker = begin
      [<Core.ImportAttribute ("ticker.Ticker", "pixi.js")>]
      type Ticker =
        class
          new : unit -> Ticker
          member _cancelIfNeeded : unit -> unit
          member _requestIfNeeded : unit -> unit
          member _startIfPossible : unit -> unit
          member _tick : time:float -> unit
          member add : fn:System.Func<float,unit> * ?context:obj -> Ticker
          member addOnce : fn:System.Func<float,unit> * ?context:obj -> Ticker
          member FPS : float
          member _emitter : EventEmitter
          member _maxElapsedMS : float
          member _requestId : float
          member autoStart : bool
          member deltaTime : float
          member elapsedMS : float
          member lastTime : float
          member minFPS : float
          member speed : float
          member started : bool
          member remove : fn:System.Func<float,unit> * ?context:obj -> Ticker
          member FPS : float with set
          member _emitter : EventEmitter with set
          member _maxElapsedMS : float with set
          member _requestId : float with set
          member autoStart : bool with set
          member deltaTime : float with set
          member elapsedMS : float with set
          member lastTime : float with set
          member minFPS : float with set
          member speed : float with set
          member started : bool with set
          member start : unit -> unit
          member stop : unit -> unit
          member update : unit -> unit
        end
      [<Core.ImportAttribute ("ticker", "pixi.js")>]
      type Globals =
        class
          static member shared : Ticker
          static member shared : Ticker with set
        end
    end
    [<Core.ImportAttribute ("*", "pixi.js")>]
    type Globals =
      class
        static member
          autoDetectRenderer : width:float * height:float *
                               ?options:RendererOptions list * ?noWebGL:bool ->
                                 Core.U2<WebGLRenderer,CanvasRenderer>
        static member BLEND_MODES : BlendModes
        static member DEFAULT_RENDER_OPTIONS : DefaultRenderOptions
        static member DEG_TO_RAD : float
        static member DRAW_MODES : DrawModes
        static member FILTER_RESOLUTION : float
        static member PI_2 : float
        static member RAD_TO_DEG : float
        static member RENDERER_TYPE : RendererType
        static member RESOLUTION : float
        static member RETINA_PREFIX : string
        static member SCALE_MODES : ScaleModes
        static member SHAPES : Shapes
        static member SPRITE_BATCH_SIZE : float
        static member TARGET_FPMS : float
        static member VERSION : string
        static member loader : loaders.Loader
      end
  end

module Data
type TerrainType =
  | Lava
  | Spikes
  | Ground
  | Start
  | Treasure
type TerrainMap = TerrainType [] []
val parseMap : input:string -> TerrainType [] []
val levels : TerrainType [] [] list
val mapIndexes : map:TerrainMap -> t:TerrainType -> seq<int * int>
type Event =
  | Button1
  | Button2
type Direction =
  | Left
  | Right
  | Up
  | Down
  with
    static member TurnLeft : (Direction -> Direction)
    static member TurnRight : (Direction -> Direction)
  end
type Location =
  | Frontof of Location
  | Leftof of Location
  | Rightof of Location
  | Backof of Location
  | Me
type TileVal =
  | On of Location
  | In of Location
  | To of Location
  | Lava
  | Spikes
  | Clear
type Predicate =
  | Is of TileVal * TileVal
  | When of Event
type Behavior =
  | Left
  | Right
  | Smash
  | Forward
  | Hop of int
  | Time of int * Behavior
  | Seek
  | If of Predicate * Behavior * Behavior
  | Say of string
  | Do of Behavior list
type BehaviorState =
  | Succeeded
  | Failed
  | Active
type Execution =
  {Proceed: SpawnFunc -> BehaviorState;
   Print: unit -> string;}
and SpawnFunc = Behavior -> Execution
type Scope =
  class
    new : unit -> Scope
    member Get : key:string -> 't option
    member GetChild : unit -> Execution option
    member Init : key:string * defaultVal:(unit -> 't) -> unit
    member Set : key:string * value:'t -> unit
    member SetChild : v:Execution -> unit
  end
val defer : x:'a -> unit -> 'a
val spawner : bhv:Behavior -> Execution
val execute :
  scope:Scope -> behavior:Behavior -> spawn:SpawnFunc -> BehaviorState
val print : scope:Scope -> behavior:Behavior -> string
val count : int ref
val loopToCompletion : execution:Execution -> unit
val peek :
  map:TerrainType [] [] * mn:(int * int) * currentFacing:Direction *
  loc:Location -> TerrainType option

module Utils
[<Fable.Core.EmitAttribute ("Math.floor(Math.random() * $0) + 1")>]
val random : n:int -> int
[<Fable.Core.EmitAttribute ("Math.random() * $0")>]
val randomRational : n:float -> float
val randomPick : vals:'t list -> 't
module Keys = begin
  val mutable pressed : System.Collections.Generic.List<int>
end

namespace Scram
  module Map = begin
    val tilesize : float
    val top : float
    val left : float
    type MoveableSprite =
      class
        inherit Fable.Import.PIXI.Sprite
        new : unit -> MoveableSprite
        member xdest : float
        member ydest : float
        member xdest : float with set
        member ydest : float with set
      end
    val makeAnimation :
      url:string * size:int * spritecoords:(int * int) list ->
        Fable.Import.PIXI.extras.MovieClip
    val lava : stage:Fable.Import.PIXI.Container -> x:float * y:float -> unit
    val ground : stage:Fable.Import.PIXI.Container -> x:float * y:float -> unit
    val spikes : stage:Fable.Import.PIXI.Container -> x:float * y:float -> unit
    val treasure :
      stage:Fable.Import.PIXI.Container -> x:float * y:float -> unit
    val mutable levelIndex : int
    val mutable currentLevel : Data.TerrainMap
    val setLevel : lvl:Data.TerrainMap -> unit
    val gr : Fable.Import.PIXI.Graphics
    val renderLevel :
      stage:Fable.Import.PIXI.Container -> level:Data.TerrainMap -> unit
    val isDeadly : m:int -> n:int -> bool
    val isTreasure : m:int -> n:int -> bool
  end

module Robot
val addUnicorn : container:Fable.Import.PIXI.Container -> unit
val addText :
  stage:Fable.Import.PIXI.Container ->
    msg:string -> color1:string -> color2:string -> unit
val RotationAngle : _arg1:Data.Direction -> float
type Robot =
  class
    new : image:string * map:Data.TerrainMap *
          computeInstructions:(Robot -> Data.Behavior list) -> Robot
    member EverySecond : unit -> unit
    member Peek : location:Data.Location -> Data.TerrainType option
    member PlaceOnMap : c:Fable.Import.PIXI.Container -> unit
    member SetDest : e:Fable.Import.PIXI.InteractionEvent -> unit
    member Update : unit -> unit
    member Coords : int * int
    member IsDead : bool
    member IsWinner : bool
  end
val KLeft : int
val KRight : int
val KUp : int
val KDown : int
val KEnter : int
val alienBrain : robot:Robot -> Data.Behavior list
val unicornBrain : robot:'a -> Data.Behavior list
val mutable robots : Robot list
val mutable levelCount : int
val setupNewLevel : stage:Fable.Import.PIXI.Container -> unit
val onStart : stage:Fable.Import.PIXI.Container -> unit
val onClick : stage:'a * e:Fable.Import.PIXI.InteractionEvent -> unit

module Components
[<Fable.Core.PojoAttribute ()>]
type Stub =
  {stub: int;}
val stub : Stub
val mutable speed : int
type PixiBox =
  class
    new : canvasContainer:Fable.Import.Browser.HTMLElement -> PixiBox
    member Destroy : unit -> unit
    member Setup : unit -> unit
  end
[<Fable.Core.PojoAttribute ()>]
type DisplayBoxState =
  {box: PixiBox option;}
val go : unit -> Fable.Import.PIXI.SystemRenderer
type DisplayBox =
  class
    inherit Fable.Import.React.Component<Stub,DisplayBoxState>
    new : unit -> DisplayBox
    member componentDidMount : unit -> unit
    member componentWillUnmount : unit -> unit
    member render : unit -> Fable.Import.React.ReactElement
  end
val RobotApp : unit -> Fable.Import.React.ReactElement

namespace TeaganSquish
  module Main = begin
  end

