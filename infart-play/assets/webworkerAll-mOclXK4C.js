import{E as p,U as je,T as Z,k as S,c as ce,F as y,s as w,M as v,a2 as X,R as j,w as M,z as he,$ as G,a0 as fe,b as U,B as T,Y as C,a9 as L,x as A,aa as Ne,ab as N,J as I,ac as B,q,t as qe,G as Qe,ad as H,m as pe,p as me,a4 as ge,a7 as xe,n as Ke,o as Je,a5 as Ze,a6 as et,a8 as tt,ae as rt,af as st,ag as it,ah as Y,ai as nt,aj as at,D as _e,l as be,ak as z,e as b,al as ot}from"./index-BXYQ2HPp.js";import{S as k,c as D,a as ut,b as lt,B as ye}from"./colorToUniform-DmtBy-2V.js";class Te{static init(e){Object.defineProperty(this,"resizeTo",{set(t){globalThis.removeEventListener("resize",this.queueResize),this._resizeTo=t,t&&(globalThis.addEventListener("resize",this.queueResize),this.resize())},get(){return this._resizeTo}}),this.queueResize=()=>{this._resizeTo&&(this._cancelResize(),this._resizeId=requestAnimationFrame(()=>this.resize()))},this._cancelResize=()=>{this._resizeId&&(cancelAnimationFrame(this._resizeId),this._resizeId=null)},this.resize=()=>{if(!this._resizeTo)return;this._cancelResize();let t,r;if(this._resizeTo===globalThis.window)t=globalThis.innerWidth,r=globalThis.innerHeight;else{const{clientWidth:s,clientHeight:n}=this._resizeTo;t=s,r=n}this.renderer.resize(t,r),this.render()},this._resizeId=null,this._resizeTo=null,this.resizeTo=e.resizeTo||null}static destroy(){globalThis.removeEventListener("resize",this.queueResize),this._cancelResize(),this._cancelResize=null,this.queueResize=null,this.resizeTo=null,this.resize=null}}Te.extension=p.Application;class ve{static init(e){e=Object.assign({autoStart:!0,sharedTicker:!1},e),Object.defineProperty(this,"ticker",{set(t){this._ticker&&this._ticker.remove(this.render,this),this._ticker=t,t&&t.add(this.render,this,je.LOW)},get(){return this._ticker}}),this.stop=()=>{this._ticker.stop()},this.start=()=>{this._ticker.start()},this._ticker=null,this.ticker=e.sharedTicker?Z.shared:new Z,e.autoStart&&this.start()}static destroy(){if(this._ticker){const e=this._ticker;this.ticker=null,e.destroy()}}}ve.extension=p.Application;class we{constructor(e){this._renderer=e}push(e,t,r){this._renderer.renderPipes.batch.break(r),r.add({renderPipeId:"filter",canBundle:!1,action:"pushFilter",container:t,filterEffect:e})}pop(e,t,r){this._renderer.renderPipes.batch.break(r),r.add({renderPipeId:"filter",action:"popFilter",canBundle:!1})}execute(e){e.action==="pushFilter"?this._renderer.filter.push(e):e.action==="popFilter"&&this._renderer.filter.pop()}destroy(){this._renderer=null}}we.extension={type:[p.WebGLPipes,p.WebGPUPipes,p.CanvasPipes],name:"filter"};function dt(i,e){e.clear();const t=e.matrix;for(let r=0;r<i.length;r++){const s=i[r];s.globalDisplayStatus<7||(e.matrix=s.worldTransform,e.addBounds(s.bounds))}return e.matrix=t,e}const ct=new X({attributes:{aPosition:{buffer:new Float32Array([0,0,1,0,1,1,0,1]),format:"float32x2",stride:2*4,offset:0}},indexBuffer:new Uint32Array([0,1,2,0,2,3])});class ht{constructor(){this.skip=!1,this.inputTexture=null,this.backTexture=null,this.filters=null,this.bounds=new he,this.container=null,this.blendRequired=!1,this.outputRenderSurface=null,this.globalFrame={x:0,y:0,width:0,height:0}}}class Pe{constructor(e){this._filterStackIndex=0,this._filterStack=[],this._filterGlobalUniforms=new S({uInputSize:{value:new Float32Array(4),type:"vec4<f32>"},uInputPixel:{value:new Float32Array(4),type:"vec4<f32>"},uInputClamp:{value:new Float32Array(4),type:"vec4<f32>"},uOutputFrame:{value:new Float32Array(4),type:"vec4<f32>"},uGlobalFrame:{value:new Float32Array(4),type:"vec4<f32>"},uOutputTexture:{value:new Float32Array(4),type:"vec4<f32>"}}),this._globalFilterBindGroup=new ce({}),this.renderer=e}get activeBackTexture(){var e;return(e=this._activeFilterData)==null?void 0:e.backTexture}push(e){const t=this.renderer,r=e.filterEffect.filters,s=this._pushFilterData();s.skip=!1,s.filters=r,s.container=e.container,s.outputRenderSurface=t.renderTarget.renderSurface;const n=t.renderTarget.renderTarget.colorTexture.source,a=n.resolution,o=n.antialias;if(r.length===0){s.skip=!0;return}const u=s.bounds;if(this._calculateFilterArea(e,u),this._calculateFilterBounds(s,t.renderTarget.rootViewPort,o,a,1),s.skip)return;const d=this._getPreviousFilterData(),h=this._findFilterResolution(a);let l=0,c=0;d&&(l=d.bounds.minX,c=d.bounds.minY),this._calculateGlobalFrame(s,l,c,h,n.width,n.height),this._setupFilterTextures(s,u,t,d)}generateFilteredTexture({texture:e,filters:t}){const r=this._pushFilterData();this._activeFilterData=r,r.skip=!1,r.filters=t;const s=e.source,n=s.resolution,a=s.antialias;if(t.length===0)return r.skip=!0,e;const o=r.bounds;if(o.addRect(e.frame),this._calculateFilterBounds(r,o.rectangle,a,n,0),r.skip)return e;const u=n;this._calculateGlobalFrame(r,0,0,u,s.width,s.height),r.outputRenderSurface=y.getOptimalTexture(o.width,o.height,r.resolution,r.antialias),r.backTexture=w.EMPTY,r.inputTexture=e,this.renderer.renderTarget.finishRenderPass(),this._applyFiltersToTexture(r,!0);const c=r.outputRenderSurface;return c.source.alphaMode="premultiplied-alpha",c}pop(){const e=this.renderer,t=this._popFilterData();t.skip||(e.globalUniforms.pop(),e.renderTarget.finishRenderPass(),this._activeFilterData=t,this._applyFiltersToTexture(t,!1),t.blendRequired&&y.returnTexture(t.backTexture),y.returnTexture(t.inputTexture))}getBackTexture(e,t,r){const s=e.colorTexture.source._resolution,n=y.getOptimalTexture(t.width,t.height,s,!1);let a=t.minX,o=t.minY;r&&(a-=r.minX,o-=r.minY),a=Math.floor(a*s),o=Math.floor(o*s);const u=Math.ceil(t.width*s),d=Math.ceil(t.height*s);return this.renderer.renderTarget.copyToTexture(e,n,{x:a,y:o},{width:u,height:d},{x:0,y:0}),n}applyFilter(e,t,r,s){const n=this.renderer,a=this._activeFilterData,u=a.outputRenderSurface===r,d=n.renderTarget.rootRenderTarget.colorTexture.source._resolution,h=this._findFilterResolution(d);let l=0,c=0;if(u){const f=this._findPreviousFilterOffset();l=f.x,c=f.y}this._updateFilterUniforms(t,r,a,l,c,h,u,s),this._setupBindGroupsAndRender(e,t,n)}calculateSpriteMatrix(e,t){const r=this._activeFilterData,s=e.set(r.inputTexture._source.width,0,0,r.inputTexture._source.height,r.bounds.minX,r.bounds.minY),n=t.worldTransform.copyTo(v.shared),a=t.renderGroup||t.parentRenderGroup;return a&&a.cacheToLocalTransform&&n.prepend(a.cacheToLocalTransform),n.invert(),s.prepend(n),s.scale(1/t.texture.frame.width,1/t.texture.frame.height),s.translate(t.anchor.x,t.anchor.y),s}destroy(){}_setupBindGroupsAndRender(e,t,r){if(r.renderPipes.uniformBatch){const s=r.renderPipes.uniformBatch.getUboResource(this._filterGlobalUniforms);this._globalFilterBindGroup.setResource(s,0)}else this._globalFilterBindGroup.setResource(this._filterGlobalUniforms,0);this._globalFilterBindGroup.setResource(t.source,1),this._globalFilterBindGroup.setResource(t.source.style,2),e.groups[0]=this._globalFilterBindGroup,r.encoder.draw({geometry:ct,shader:e,state:e._state,topology:"triangle-list"}),r.type===j.WEBGL&&r.renderTarget.finishRenderPass()}_setupFilterTextures(e,t,r,s){if(e.backTexture=w.EMPTY,e.blendRequired){r.renderTarget.finishRenderPass();const n=r.renderTarget.getRenderTarget(e.outputRenderSurface);e.backTexture=this.getBackTexture(n,t,s==null?void 0:s.bounds)}e.inputTexture=y.getOptimalTexture(t.width,t.height,e.resolution,e.antialias),r.renderTarget.bind(e.inputTexture,!0),r.globalUniforms.push({offset:t})}_calculateGlobalFrame(e,t,r,s,n,a){const o=e.globalFrame;o.x=t*s,o.y=r*s,o.width=n*s,o.height=a*s}_updateFilterUniforms(e,t,r,s,n,a,o,u){const d=this._filterGlobalUniforms.uniforms,h=d.uOutputFrame,l=d.uInputSize,c=d.uInputPixel,f=d.uInputClamp,_=d.uGlobalFrame,g=d.uOutputTexture;o?(h[0]=r.bounds.minX-s,h[1]=r.bounds.minY-n):(h[0]=0,h[1]=0),h[2]=e.frame.width,h[3]=e.frame.height,l[0]=e.source.width,l[1]=e.source.height,l[2]=1/l[0],l[3]=1/l[1],c[0]=e.source.pixelWidth,c[1]=e.source.pixelHeight,c[2]=1/c[0],c[3]=1/c[1],f[0]=.5*c[2],f[1]=.5*c[3],f[2]=e.frame.width*l[2]-.5*c[2],f[3]=e.frame.height*l[3]-.5*c[3];const m=this.renderer.renderTarget.rootRenderTarget.colorTexture;_[0]=s*a,_[1]=n*a,_[2]=m.source.width*a,_[3]=m.source.height*a,t instanceof w&&(t.source.resource=null);const x=this.renderer.renderTarget.getRenderTarget(t);this.renderer.renderTarget.bind(t,!!u),t instanceof w?(g[0]=t.frame.width,g[1]=t.frame.height):(g[0]=x.width,g[1]=x.height),g[2]=x.isRoot?-1:1,this._filterGlobalUniforms.update()}_findFilterResolution(e){let t=this._filterStackIndex-1;for(;t>0&&this._filterStack[t].skip;)--t;return t>0&&this._filterStack[t].inputTexture?this._filterStack[t].inputTexture.source._resolution:e}_findPreviousFilterOffset(){let e=0,t=0,r=this._filterStackIndex;for(;r>0;){r--;const s=this._filterStack[r];if(!s.skip){e=s.bounds.minX,t=s.bounds.minY;break}}return{x:e,y:t}}_calculateFilterArea(e,t){if(e.renderables?dt(e.renderables,t):e.filterEffect.filterArea?(t.clear(),t.addRect(e.filterEffect.filterArea),t.applyMatrix(e.container.worldTransform)):e.container.getFastGlobalBounds(!0,t),e.container){const s=(e.container.renderGroup||e.container.parentRenderGroup).cacheToLocalTransform;s&&t.applyMatrix(s)}}_applyFiltersToTexture(e,t){const r=e.inputTexture,s=e.bounds,n=e.filters;if(this._globalFilterBindGroup.setResource(r.source.style,2),this._globalFilterBindGroup.setResource(e.backTexture.source,3),n.length===1)n[0].apply(this,r,e.outputRenderSurface,t);else{let a=e.inputTexture;const o=y.getOptimalTexture(s.width,s.height,a.source._resolution,!1);let u=o,d=0;for(d=0;d<n.length-1;++d){n[d].apply(this,a,u,!0);const l=a;a=u,u=l}n[d].apply(this,a,e.outputRenderSurface,t),y.returnTexture(o)}}_calculateFilterBounds(e,t,r,s,n){var g;const a=this.renderer,o=e.bounds,u=e.filters;let d=1/0,h=0,l=!0,c=!1,f=!1,_=!0;for(let m=0;m<u.length;m++){const x=u[m];if(d=Math.min(d,x.resolution==="inherit"?s:x.resolution),h+=x.padding,x.antialias==="off"?l=!1:x.antialias==="inherit"&&l&&(l=r),x.clipToViewport||(_=!1),!!!(x.compatibleRenderers&a.type)){f=!1;break}if(x.blendRequired&&!(((g=a.backBuffer)==null?void 0:g.useBackBuffer)??!0)){M("Blend filter requires backBuffer on WebGL renderer to be enabled. Set `useBackBuffer: true` in the renderer options."),f=!1;break}f=x.enabled||f,c||(c=x.blendRequired)}if(!f){e.skip=!0;return}if(_&&o.fitBounds(0,t.width/s,0,t.height/s),o.scale(d).ceil().scale(1/d).pad((h|0)*n),!o.isPositive){e.skip=!0;return}e.antialias=l,e.resolution=d,e.blendRequired=c}_popFilterData(){return this._filterStackIndex--,this._filterStack[this._filterStackIndex]}_getPreviousFilterData(){let e,t=this._filterStackIndex-1;for(;t>1&&(t--,e=this._filterStack[t],!!e.skip););return e}_pushFilterData(){let e=this._filterStack[this._filterStackIndex];return e||(e=this._filterStack[this._filterStackIndex]=new ht),this._filterStackIndex++,e}}Pe.extension={type:[p.WebGLSystem,p.WebGPUSystem],name:"filter"};const Se=class Ce extends X{constructor(...e){let t=e[0]??{};t instanceof Float32Array&&(G(fe,"use new MeshGeometry({ positions, uvs, indices }) instead"),t={positions:t,uvs:e[1],indices:e[2]}),t={...Ce.defaultOptions,...t};const r=t.positions||new Float32Array([0,0,1,0,1,1,0,1]);let s=t.uvs;s||(t.positions?s=new Float32Array(r.length):s=new Float32Array([0,0,1,0,1,1,0,1]));const n=t.indices||new Uint32Array([0,1,2,0,2,3]),a=t.shrinkBuffersToFit,o=new U({data:r,label:"attribute-mesh-positions",shrinkToFit:a,usage:T.VERTEX|T.COPY_DST}),u=new U({data:s,label:"attribute-mesh-uvs",shrinkToFit:a,usage:T.VERTEX|T.COPY_DST}),d=new U({data:n,label:"index-mesh-buffer",shrinkToFit:a,usage:T.INDEX|T.COPY_DST});super({attributes:{aPosition:{buffer:o,format:"float32x2",stride:2*4,offset:0},aUV:{buffer:u,format:"float32x2",stride:2*4,offset:0}},indexBuffer:d,topology:t.topology}),this.batchMode="auto"}get positions(){return this.attributes.aPosition.buffer.data}set positions(e){this.attributes.aPosition.buffer.data=e}get uvs(){return this.attributes.aUV.buffer.data}set uvs(e){this.attributes.aUV.buffer.data=e}get indices(){return this.indexBuffer.data}set indices(e){this.indexBuffer.data=e}};Se.defaultOptions={topology:"triangle-list",shrinkBuffersToFit:!1};let Q=Se;function ft(i){const e=i._stroke,t=i._fill,s=[`div { ${[`color: ${C.shared.setValue(t.color).toHex()}`,`font-size: ${i.fontSize}px`,`font-family: ${i.fontFamily}`,`font-weight: ${i.fontWeight}`,`font-style: ${i.fontStyle}`,`font-variant: ${i.fontVariant}`,`letter-spacing: ${i.letterSpacing}px`,`text-align: ${i.align}`,`padding: ${i.padding}px`,`white-space: ${i.whiteSpace==="pre"&&i.wordWrap?"pre-wrap":i.whiteSpace}`,...i.lineHeight?[`line-height: ${i.lineHeight}px`]:[],...i.wordWrap?[`word-wrap: ${i.breakWords?"break-all":"break-word"}`,`max-width: ${i.wordWrapWidth}px`]:[],...e?[Be(e)]:[],...i.dropShadow?[Ue(i.dropShadow)]:[],...i.cssOverrides].join(";")} }`];return pt(i.tagStyles,s),s.join(" ")}function Ue(i){const e=C.shared.setValue(i.color).setAlpha(i.alpha).toHexa(),t=Math.round(Math.cos(i.angle)*i.distance),r=Math.round(Math.sin(i.angle)*i.distance),s=`${t}px ${r}px`;return i.blur>0?`text-shadow: ${s} ${i.blur}px ${e}`:`text-shadow: ${s} ${e}`}function Be(i){return[`-webkit-text-stroke-width: ${i.width}px`,`-webkit-text-stroke-color: ${C.shared.setValue(i.color).toHex()}`,`text-stroke-width: ${i.width}px`,`text-stroke-color: ${C.shared.setValue(i.color).toHex()}`,"paint-order: stroke"].join(";")}const ee={fontSize:"font-size: {{VALUE}}px",fontFamily:"font-family: {{VALUE}}",fontWeight:"font-weight: {{VALUE}}",fontStyle:"font-style: {{VALUE}}",fontVariant:"font-variant: {{VALUE}}",letterSpacing:"letter-spacing: {{VALUE}}px",align:"text-align: {{VALUE}}",padding:"padding: {{VALUE}}px",whiteSpace:"white-space: {{VALUE}}",lineHeight:"line-height: {{VALUE}}px",wordWrapWidth:"max-width: {{VALUE}}px"},te={fill:i=>`color: ${C.shared.setValue(i).toHex()}`,breakWords:i=>`word-wrap: ${i?"break-all":"break-word"}`,stroke:Be,dropShadow:Ue};function pt(i,e){for(const t in i){const r=i[t],s=[];for(const n in r)te[n]?s.push(te[n](r[n])):ee[n]&&s.push(ee[n].replace("{{VALUE}}",r[n]));e.push(`${t} { ${s.join(";")} }`)}}class K extends L{constructor(e={}){super(e),this._cssOverrides=[],this.cssOverrides=e.cssOverrides??[],this.tagStyles=e.tagStyles??{}}set cssOverrides(e){this._cssOverrides=e instanceof Array?e:[e],this.update()}get cssOverrides(){return this._cssOverrides}update(){this._cssStyle=null,super.update()}clone(){return new K({align:this.align,breakWords:this.breakWords,dropShadow:this.dropShadow?{...this.dropShadow}:null,fill:this._fill,fontFamily:this.fontFamily,fontSize:this.fontSize,fontStyle:this.fontStyle,fontVariant:this.fontVariant,fontWeight:this.fontWeight,letterSpacing:this.letterSpacing,lineHeight:this.lineHeight,padding:this.padding,stroke:this._stroke,whiteSpace:this.whiteSpace,wordWrap:this.wordWrap,wordWrapWidth:this.wordWrapWidth,cssOverrides:this.cssOverrides,tagStyles:{...this.tagStyles}})}get cssStyle(){return this._cssStyle||(this._cssStyle=ft(this)),this._cssStyle}addOverride(...e){const t=e.filter(r=>!this.cssOverrides.includes(r));t.length>0&&(this.cssOverrides.push(...t),this.update())}removeOverride(...e){const t=e.filter(r=>this.cssOverrides.includes(r));t.length>0&&(this.cssOverrides=this.cssOverrides.filter(r=>!t.includes(r)),this.update())}set fill(e){typeof e!="string"&&typeof e!="number"&&M("[HTMLTextStyle] only color fill is not supported by HTMLText"),super.fill=e}set stroke(e){e&&typeof e!="string"&&typeof e!="number"&&M("[HTMLTextStyle] only color stroke is not supported by HTMLText"),super.stroke=e}}const re="http://www.w3.org/2000/svg",se="http://www.w3.org/1999/xhtml";class Fe{constructor(){this.svgRoot=document.createElementNS(re,"svg"),this.foreignObject=document.createElementNS(re,"foreignObject"),this.domElement=document.createElementNS(se,"div"),this.styleElement=document.createElementNS(se,"style"),this.image=new Image;const{foreignObject:e,svgRoot:t,styleElement:r,domElement:s}=this;e.setAttribute("width","10000"),e.setAttribute("height","10000"),e.style.overflow="hidden",t.appendChild(e),e.appendChild(r),e.appendChild(s)}}let ie;function mt(i,e,t,r){r||(r=ie||(ie=new Fe));const{domElement:s,styleElement:n,svgRoot:a}=r;s.innerHTML=`<style>${e.cssStyle};</style><div style='padding:0'>${i}</div>`,s.setAttribute("style","transform-origin: top left; display: inline-block"),t&&(n.textContent=t),document.body.appendChild(a);const o=s.getBoundingClientRect();a.remove();const u=e.padding*2;return{width:o.width-u,height:o.height-u}}class gt{constructor(){this.batches=[],this.batched=!1}destroy(){this.batches.forEach(e=>{A.return(e)}),this.batches.length=0}}class Re{constructor(e,t){this.state=k.for2d(),this.renderer=e,this._adaptor=t,this.renderer.runners.contextChange.add(this)}contextChange(){this._adaptor.contextChange(this.renderer)}validateRenderable(e){const t=e.context,r=!!e._gpuData,s=this.renderer.graphicsContext.updateGpuContext(t);return!!(s.isBatchable||r!==s.isBatchable)}addRenderable(e,t){const r=this.renderer.graphicsContext.updateGpuContext(e.context);e.didViewUpdate&&this._rebuild(e),r.isBatchable?this._addToBatcher(e,t):(this.renderer.renderPipes.batch.break(t),t.add(e))}updateRenderable(e){const r=this._getGpuDataForRenderable(e).batches;for(let s=0;s<r.length;s++){const n=r[s];n._batcher.updateElement(n)}}execute(e){if(!e.isRenderable)return;const t=this.renderer,r=e.context;if(!t.graphicsContext.getGpuContext(r).batches.length)return;const n=r.customShader||this._adaptor.shader;this.state.blendMode=e.groupBlendMode;const a=n.resources.localUniforms.uniforms;a.uTransformMatrix=e.groupTransform,a.uRound=t._roundPixels|e._roundPixels,D(e.groupColorAlpha,a.uColor,0),this._adaptor.execute(this,e)}_rebuild(e){const t=this._getGpuDataForRenderable(e),r=this.renderer.graphicsContext.updateGpuContext(e.context);t.destroy(),r.isBatchable&&this._updateBatchesForRenderable(e,t)}_addToBatcher(e,t){const r=this.renderer.renderPipes.batch,s=this._getGpuDataForRenderable(e).batches;for(let n=0;n<s.length;n++){const a=s[n];r.addToBatch(a,t)}}_getGpuDataForRenderable(e){return e._gpuData[this.renderer.uid]||this._initGpuDataForRenderable(e)}_initGpuDataForRenderable(e){const t=new gt;return e._gpuData[this.renderer.uid]=t,t}_updateBatchesForRenderable(e,t){const r=e.context,s=this.renderer.graphicsContext.getGpuContext(r),n=this.renderer._roundPixels|e._roundPixels;t.batches=s.batches.map(a=>{const o=A.get(Ne);return a.copyTo(o),o.renderable=e,o.roundPixels=n,o})}destroy(){this.renderer=null,this._adaptor.destroy(),this._adaptor=null,this.state=null}}Re.extension={type:[p.WebGLPipes,p.WebGPUPipes,p.CanvasPipes],name:"graphics"};const Me=class Ge extends Q{constructor(...e){super({});let t=e[0]??{};typeof t=="number"&&(G(fe,"PlaneGeometry constructor changed please use { width, height, verticesX, verticesY } instead"),t={width:t,height:e[1],verticesX:e[2],verticesY:e[3]}),this.build(t)}build(e){e={...Ge.defaultOptions,...e},this.verticesX=this.verticesX??e.verticesX,this.verticesY=this.verticesY??e.verticesY,this.width=this.width??e.width,this.height=this.height??e.height;const t=this.verticesX*this.verticesY,r=[],s=[],n=[],a=this.verticesX-1,o=this.verticesY-1,u=this.width/a,d=this.height/o;for(let l=0;l<t;l++){const c=l%this.verticesX,f=l/this.verticesX|0;r.push(c*u,f*d),s.push(c/a,f/o)}const h=a*o;for(let l=0;l<h;l++){const c=l%a,f=l/a|0,_=f*this.verticesX+c,g=f*this.verticesX+c+1,m=(f+1)*this.verticesX+c,x=(f+1)*this.verticesX+c+1;n.push(_,g,m,g,x,m)}this.buffers[0].data=new Float32Array(r),this.buffers[1].data=new Float32Array(s),this.indexBuffer.data=new Uint32Array(n),this.buffers[0].update(),this.buffers[1].update(),this.indexBuffer.update()}};Me.defaultOptions={width:100,height:100,verticesX:10,verticesY:10};let xt=Me;class J{constructor(){this.batcherName="default",this.packAsQuad=!1,this.indexOffset=0,this.attributeOffset=0,this.roundPixels=0,this._batcher=null,this._batch=null,this._textureMatrixUpdateId=-1,this._uvUpdateId=-1}get blendMode(){return this.renderable.groupBlendMode}get topology(){return this._topology||this.geometry.topology}set topology(e){this._topology=e}reset(){this.renderable=null,this.texture=null,this._batcher=null,this._batch=null,this.geometry=null,this._uvUpdateId=-1,this._textureMatrixUpdateId=-1}setTexture(e){this.texture!==e&&(this.texture=e,this._textureMatrixUpdateId=-1)}get uvs(){const t=this.geometry.getBuffer("aUV"),r=t.data;let s=r;const n=this.texture.textureMatrix;return n.isSimple||(s=this._transformedUvs,(this._textureMatrixUpdateId!==n._updateID||this._uvUpdateId!==t._updateID)&&((!s||s.length<r.length)&&(s=this._transformedUvs=new Float32Array(r.length)),this._textureMatrixUpdateId=n._updateID,this._uvUpdateId=t._updateID,n.multiplyUvs(r,s))),s}get positions(){return this.geometry.positions}get indices(){return this.geometry.indices}get color(){return this.renderable.groupColorAlpha}get groupTransform(){return this.renderable.groupTransform}get attributeSize(){return this.geometry.positions.length/2}get indexSize(){return this.geometry.indices.length}}class ne{destroy(){}}class Ae{constructor(e,t){this.localUniforms=new S({uTransformMatrix:{value:new v,type:"mat3x3<f32>"},uColor:{value:new Float32Array([1,1,1,1]),type:"vec4<f32>"},uRound:{value:0,type:"f32"}}),this.localUniformsBindGroup=new ce({0:this.localUniforms}),this.renderer=e,this._adaptor=t,this._adaptor.init()}validateRenderable(e){const t=this._getMeshData(e),r=t.batched,s=e.batched;if(t.batched=s,r!==s)return!0;if(s){const n=e._geometry;if(n.indices.length!==t.indexSize||n.positions.length!==t.vertexSize)return t.indexSize=n.indices.length,t.vertexSize=n.positions.length,!0;const a=this._getBatchableMesh(e);return a.texture.uid!==e._texture.uid&&(a._textureMatrixUpdateId=-1),!a._batcher.checkAndUpdateTexture(a,e._texture)}return!1}addRenderable(e,t){const r=this.renderer.renderPipes.batch,{batched:s}=this._getMeshData(e);if(s){const n=this._getBatchableMesh(e);n.setTexture(e._texture),n.geometry=e._geometry,r.addToBatch(n,t)}else r.break(t),t.add(e)}updateRenderable(e){if(e.batched){const t=this._getBatchableMesh(e);t.setTexture(e._texture),t.geometry=e._geometry,t._batcher.updateElement(t)}}execute(e){if(!e.isRenderable)return;e.state.blendMode=N(e.groupBlendMode,e.texture._source);const t=this.localUniforms;t.uniforms.uTransformMatrix=e.groupTransform,t.uniforms.uRound=this.renderer._roundPixels|e._roundPixels,t.update(),D(e.groupColorAlpha,t.uniforms.uColor,0),this._adaptor.execute(this,e)}_getMeshData(e){var t,r;return(t=e._gpuData)[r=this.renderer.uid]||(t[r]=new ne),e._gpuData[this.renderer.uid].meshData||this._initMeshData(e)}_initMeshData(e){var t,r;return e._gpuData[this.renderer.uid].meshData={batched:e.batched,indexSize:(t=e._geometry.indices)==null?void 0:t.length,vertexSize:(r=e._geometry.positions)==null?void 0:r.length},e._gpuData[this.renderer.uid].meshData}_getBatchableMesh(e){var t,r;return(t=e._gpuData)[r=this.renderer.uid]||(t[r]=new ne),e._gpuData[this.renderer.uid].batchableMesh||this._initBatchableMesh(e)}_initBatchableMesh(e){const t=new J;return t.renderable=e,t.setTexture(e._texture),t.transform=e.groupTransform,t.roundPixels=this.renderer._roundPixels|e._roundPixels,e._gpuData[this.renderer.uid].batchableMesh=t,t}destroy(){this.localUniforms=null,this.localUniformsBindGroup=null,this._adaptor.destroy(),this._adaptor=null,this.renderer=null}}Ae.extension={type:[p.WebGLPipes,p.WebGPUPipes,p.CanvasPipes],name:"mesh"};class _t{execute(e,t){const r=e.state,s=e.renderer,n=t.shader||e.defaultShader;n.resources.uTexture=t.texture._source,n.resources.uniforms=e.localUniforms;const a=s.gl,o=e.getBuffers(t);s.shader.bind(n),s.state.set(r),s.geometry.bind(o.geometry,n.glProgram);const d=o.geometry.indexBuffer.data.BYTES_PER_ELEMENT===2?a.UNSIGNED_SHORT:a.UNSIGNED_INT;a.drawElements(a.TRIANGLES,t.particleChildren.length*6,d,0)}}class bt{execute(e,t){const r=e.renderer,s=t.shader||e.defaultShader;s.groups[0]=r.renderPipes.uniformBatch.getUniformBindGroup(e.localUniforms,!0),s.groups[1]=r.texture.getTextureBindGroup(t.texture);const n=e.state,a=e.getBuffers(t);r.encoder.draw({geometry:a.geometry,shader:t.shader||e.defaultShader,state:n,size:t.particleChildren.length*6})}}function ae(i,e=null){const t=i*6;if(t>65535?e||(e=new Uint32Array(t)):e||(e=new Uint16Array(t)),e.length!==t)throw new Error(`Out buffer length is incorrect, got ${e.length} and expected ${t}`);for(let r=0,s=0;r<t;r+=6,s+=4)e[r+0]=s+0,e[r+1]=s+1,e[r+2]=s+2,e[r+3]=s+0,e[r+4]=s+2,e[r+5]=s+3;return e}function yt(i){return{dynamicUpdate:oe(i,!0),staticUpdate:oe(i,!1)}}function oe(i,e){const t=[];t.push(`

        var index = 0;

        for (let i = 0; i < ps.length; ++i)
        {
            const p = ps[i];

            `);let r=0;for(const n in i){const a=i[n];if(e!==a.dynamic)continue;t.push(`offset = index + ${r}`),t.push(a.code);const o=I(a.format);r+=o.stride/4}t.push(`
            index += stride * 4;
        }
    `),t.unshift(`
        var stride = ${r};
    `);const s=t.join(`
`);return new Function("ps","f32v","u32v",s)}class Tt{constructor(e){this._size=0,this._generateParticleUpdateCache={};const t=this._size=e.size??1e3,r=e.properties;let s=0,n=0;for(const h in r){const l=r[h],c=I(l.format);l.dynamic?n+=c.stride:s+=c.stride}this._dynamicStride=n/4,this._staticStride=s/4,this.staticAttributeBuffer=new B(t*4*s),this.dynamicAttributeBuffer=new B(t*4*n),this.indexBuffer=ae(t);const a=new X;let o=0,u=0;this._staticBuffer=new U({data:new Float32Array(1),label:"static-particle-buffer",shrinkToFit:!1,usage:T.VERTEX|T.COPY_DST}),this._dynamicBuffer=new U({data:new Float32Array(1),label:"dynamic-particle-buffer",shrinkToFit:!1,usage:T.VERTEX|T.COPY_DST});for(const h in r){const l=r[h],c=I(l.format);l.dynamic?(a.addAttribute(l.attributeName,{buffer:this._dynamicBuffer,stride:this._dynamicStride*4,offset:o*4,format:l.format}),o+=c.size):(a.addAttribute(l.attributeName,{buffer:this._staticBuffer,stride:this._staticStride*4,offset:u*4,format:l.format}),u+=c.size)}a.addIndex(this.indexBuffer);const d=this.getParticleUpdate(r);this._dynamicUpload=d.dynamicUpdate,this._staticUpload=d.staticUpdate,this.geometry=a}getParticleUpdate(e){const t=vt(e);return this._generateParticleUpdateCache[t]?this._generateParticleUpdateCache[t]:(this._generateParticleUpdateCache[t]=this.generateParticleUpdate(e),this._generateParticleUpdateCache[t])}generateParticleUpdate(e){return yt(e)}update(e,t){e.length>this._size&&(t=!0,this._size=Math.max(e.length,this._size*1.5|0),this.staticAttributeBuffer=new B(this._size*this._staticStride*4*4),this.dynamicAttributeBuffer=new B(this._size*this._dynamicStride*4*4),this.indexBuffer=ae(this._size),this.geometry.indexBuffer.setDataWithSize(this.indexBuffer,this.indexBuffer.byteLength,!0));const r=this.dynamicAttributeBuffer;if(this._dynamicUpload(e,r.float32View,r.uint32View),this._dynamicBuffer.setDataWithSize(this.dynamicAttributeBuffer.float32View,e.length*this._dynamicStride*4,!0),t){const s=this.staticAttributeBuffer;this._staticUpload(e,s.float32View,s.uint32View),this._staticBuffer.setDataWithSize(s.float32View,e.length*this._staticStride*4,!0)}}destroy(){this._staticBuffer.destroy(),this._dynamicBuffer.destroy(),this.geometry.destroy()}}function vt(i){const e=[];for(const t in i){const r=i[t];e.push(t,r.code,r.dynamic?"d":"s")}return e.join("_")}var wt=`varying vec2 vUV;
varying vec4 vColor;

uniform sampler2D uTexture;

void main(void){
    vec4 color = texture2D(uTexture, vUV) * vColor;
    gl_FragColor = color;
}`,Pt=`attribute vec2 aVertex;
attribute vec2 aUV;
attribute vec4 aColor;

attribute vec2 aPosition;
attribute float aRotation;

uniform mat3 uTranslationMatrix;
uniform float uRound;
uniform vec2 uResolution;
uniform vec4 uColor;

varying vec2 vUV;
varying vec4 vColor;

vec2 roundPixels(vec2 position, vec2 targetSize)
{       
    return (floor(((position * 0.5 + 0.5) * targetSize) + 0.5) / targetSize) * 2.0 - 1.0;
}

void main(void){
    float cosRotation = cos(aRotation);
    float sinRotation = sin(aRotation);
    float x = aVertex.x * cosRotation - aVertex.y * sinRotation;
    float y = aVertex.x * sinRotation + aVertex.y * cosRotation;

    vec2 v = vec2(x, y);
    v = v + aPosition;

    gl_Position = vec4((uTranslationMatrix * vec3(v, 1.0)).xy, 0.0, 1.0);

    if(uRound == 1.0)
    {
        gl_Position.xy = roundPixels(gl_Position.xy, uResolution);
    }

    vUV = aUV;
    vColor = vec4(aColor.rgb * aColor.a, aColor.a) * uColor;
}
`,ue=`
struct ParticleUniforms {
  uProjectionMatrix:mat3x3<f32>,
  uColor:vec4<f32>,
  uResolution:vec2<f32>,
  uRoundPixels:f32,
};

@group(0) @binding(0) var<uniform> uniforms: ParticleUniforms;

@group(1) @binding(0) var uTexture: texture_2d<f32>;
@group(1) @binding(1) var uSampler : sampler;

struct VSOutput {
    @builtin(position) position: vec4<f32>,
    @location(0) uv : vec2<f32>,
    @location(1) color : vec4<f32>,
  };
@vertex
fn mainVertex(
  @location(0) aVertex: vec2<f32>,
  @location(1) aPosition: vec2<f32>,
  @location(2) aUV: vec2<f32>,
  @location(3) aColor: vec4<f32>,
  @location(4) aRotation: f32,
) -> VSOutput {
  
   let v = vec2(
       aVertex.x * cos(aRotation) - aVertex.y * sin(aRotation),
       aVertex.x * sin(aRotation) + aVertex.y * cos(aRotation)
   ) + aPosition;

   let position = vec4((uniforms.uProjectionMatrix * vec3(v, 1.0)).xy, 0.0, 1.0);

    let vColor = vec4(aColor.rgb * aColor.a, aColor.a) * uniforms.uColor;

  return VSOutput(
   position,
   aUV,
   vColor,
  );
}

@fragment
fn mainFragment(
  @location(0) uv: vec2<f32>,
  @location(1) color: vec4<f32>,
  @builtin(position) position: vec4<f32>,
) -> @location(0) vec4<f32> {

    var sample = textureSample(uTexture, uSampler, uv) * color;
   
    return sample;
}`;class St extends q{constructor(){const e=qe.from({vertex:Pt,fragment:wt}),t=Qe.from({fragment:{source:ue,entryPoint:"mainFragment"},vertex:{source:ue,entryPoint:"mainVertex"}});super({glProgram:e,gpuProgram:t,resources:{uTexture:w.WHITE.source,uSampler:new H({}),uniforms:{uTranslationMatrix:{value:new v,type:"mat3x3<f32>"},uColor:{value:new C(16777215),type:"vec4<f32>"},uRound:{value:1,type:"f32"},uResolution:{value:[0,0],type:"vec2<f32>"}}}})}}class ke{constructor(e,t){this.state=k.for2d(),this.localUniforms=new S({uTranslationMatrix:{value:new v,type:"mat3x3<f32>"},uColor:{value:new Float32Array(4),type:"vec4<f32>"},uRound:{value:1,type:"f32"},uResolution:{value:[0,0],type:"vec2<f32>"}}),this.renderer=e,this.adaptor=t,this.defaultShader=new St,this.state=k.for2d()}validateRenderable(e){return!1}addRenderable(e,t){this.renderer.renderPipes.batch.break(t),t.add(e)}getBuffers(e){return e._gpuData[this.renderer.uid]||this._initBuffer(e)}_initBuffer(e){return e._gpuData[this.renderer.uid]=new Tt({size:e.particleChildren.length,properties:e._properties}),e._gpuData[this.renderer.uid]}updateRenderable(e){}execute(e){const t=e.particleChildren;if(t.length===0)return;const r=this.renderer,s=this.getBuffers(e);e.texture||(e.texture=t[0].texture);const n=this.state;s.update(t,e._childrenDirty),e._childrenDirty=!1,n.blendMode=N(e.blendMode,e.texture._source);const a=this.localUniforms.uniforms,o=a.uTranslationMatrix;e.worldTransform.copyTo(o),o.prepend(r.globalUniforms.globalUniformData.projectionMatrix),a.uResolution=r.globalUniforms.globalUniformData.resolution,a.uRound=r._roundPixels|e._roundPixels,D(e.groupColorAlpha,a.uColor,0),this.adaptor.execute(this,e)}destroy(){this.defaultShader&&(this.defaultShader.destroy(),this.defaultShader=null)}}class De extends ke{constructor(e){super(e,new _t)}}De.extension={type:[p.WebGLPipes],name:"particle"};class ze extends ke{constructor(e){super(e,new bt)}}ze.extension={type:[p.WebGPUPipes],name:"particle"};const Ve=class We extends xt{constructor(e={}){e={...We.defaultOptions,...e},super({width:e.width,height:e.height,verticesX:4,verticesY:4}),this.update(e)}update(e){var t,r;this.width=e.width??this.width,this.height=e.height??this.height,this._originalWidth=e.originalWidth??this._originalWidth,this._originalHeight=e.originalHeight??this._originalHeight,this._leftWidth=e.leftWidth??this._leftWidth,this._rightWidth=e.rightWidth??this._rightWidth,this._topHeight=e.topHeight??this._topHeight,this._bottomHeight=e.bottomHeight??this._bottomHeight,this._anchorX=(t=e.anchor)==null?void 0:t.x,this._anchorY=(r=e.anchor)==null?void 0:r.y,this.updateUvs(),this.updatePositions()}updatePositions(){const e=this.positions,{width:t,height:r,_leftWidth:s,_rightWidth:n,_topHeight:a,_bottomHeight:o,_anchorX:u,_anchorY:d}=this,h=s+n,l=t>h?1:t/h,c=a+o,f=r>c?1:r/c,_=Math.min(l,f),g=u*t,m=d*r;e[0]=e[8]=e[16]=e[24]=-g,e[2]=e[10]=e[18]=e[26]=s*_-g,e[4]=e[12]=e[20]=e[28]=t-n*_-g,e[6]=e[14]=e[22]=e[30]=t-g,e[1]=e[3]=e[5]=e[7]=-m,e[9]=e[11]=e[13]=e[15]=a*_-m,e[17]=e[19]=e[21]=e[23]=r-o*_-m,e[25]=e[27]=e[29]=e[31]=r-m,this.getBuffer("aPosition").update()}updateUvs(){const e=this.uvs;e[0]=e[8]=e[16]=e[24]=0,e[1]=e[3]=e[5]=e[7]=0,e[6]=e[14]=e[22]=e[30]=1,e[25]=e[27]=e[29]=e[31]=1;const t=1/this._originalWidth,r=1/this._originalHeight;e[2]=e[10]=e[18]=e[26]=t*this._leftWidth,e[9]=e[11]=e[13]=e[15]=r*this._topHeight,e[4]=e[12]=e[20]=e[28]=1-t*this._rightWidth,e[17]=e[19]=e[21]=e[23]=1-r*this._bottomHeight,this.getBuffer("aUV").update()}};Ve.defaultOptions={width:100,height:100,leftWidth:10,topHeight:10,rightWidth:10,bottomHeight:10,originalWidth:100,originalHeight:100};let Ct=Ve;class Ut extends J{constructor(){super(),this.geometry=new Ct}destroy(){this.geometry.destroy()}}class Oe{constructor(e){this._renderer=e}addRenderable(e,t){const r=this._getGpuSprite(e);e.didViewUpdate&&this._updateBatchableSprite(e,r),this._renderer.renderPipes.batch.addToBatch(r,t)}updateRenderable(e){const t=this._getGpuSprite(e);e.didViewUpdate&&this._updateBatchableSprite(e,t),t._batcher.updateElement(t)}validateRenderable(e){const t=this._getGpuSprite(e);return!t._batcher.checkAndUpdateTexture(t,e._texture)}_updateBatchableSprite(e,t){t.geometry.update(e),t.setTexture(e._texture)}_getGpuSprite(e){return e._gpuData[this._renderer.uid]||this._initGPUSprite(e)}_initGPUSprite(e){const t=e._gpuData[this._renderer.uid]=new Ut,r=t;return r.renderable=e,r.transform=e.groupTransform,r.texture=e._texture,r.roundPixels=this._renderer._roundPixels|e._roundPixels,e.didViewUpdate||this._updateBatchableSprite(e,r),t}destroy(){this._renderer=null}}Oe.extension={type:[p.WebGLPipes,p.WebGPUPipes,p.CanvasPipes],name:"nineSliceSprite"};const Bt={name:"tiling-bit",vertex:{header:`
            struct TilingUniforms {
                uMapCoord:mat3x3<f32>,
                uClampFrame:vec4<f32>,
                uClampOffset:vec2<f32>,
                uTextureTransform:mat3x3<f32>,
                uSizeAnchor:vec4<f32>
            };

            @group(2) @binding(0) var<uniform> tilingUniforms: TilingUniforms;
            @group(2) @binding(1) var uTexture: texture_2d<f32>;
            @group(2) @binding(2) var uSampler: sampler;
        `,main:`
            uv = (tilingUniforms.uTextureTransform * vec3(uv, 1.0)).xy;

            position = (position - tilingUniforms.uSizeAnchor.zw) * tilingUniforms.uSizeAnchor.xy;
        `},fragment:{header:`
            struct TilingUniforms {
                uMapCoord:mat3x3<f32>,
                uClampFrame:vec4<f32>,
                uClampOffset:vec2<f32>,
                uTextureTransform:mat3x3<f32>,
                uSizeAnchor:vec4<f32>
            };

            @group(2) @binding(0) var<uniform> tilingUniforms: TilingUniforms;
            @group(2) @binding(1) var uTexture: texture_2d<f32>;
            @group(2) @binding(2) var uSampler: sampler;
        `,main:`

            var coord = vUV + ceil(tilingUniforms.uClampOffset - vUV);
            coord = (tilingUniforms.uMapCoord * vec3(coord, 1.0)).xy;
            var unclamped = coord;
            coord = clamp(coord, tilingUniforms.uClampFrame.xy, tilingUniforms.uClampFrame.zw);

            var bias = 0.;

            if(unclamped.x == coord.x && unclamped.y == coord.y)
            {
                bias = -32.;
            }

            outColor = textureSampleBias(uTexture, uSampler, coord, bias);
        `}},Ft={name:"tiling-bit",vertex:{header:`
            uniform mat3 uTextureTransform;
            uniform vec4 uSizeAnchor;

        `,main:`
            uv = (uTextureTransform * vec3(aUV, 1.0)).xy;

            position = (position - uSizeAnchor.zw) * uSizeAnchor.xy;
        `},fragment:{header:`
            uniform sampler2D uTexture;
            uniform mat3 uMapCoord;
            uniform vec4 uClampFrame;
            uniform vec2 uClampOffset;
        `,main:`

        vec2 coord = vUV + ceil(uClampOffset - vUV);
        coord = (uMapCoord * vec3(coord, 1.0)).xy;
        vec2 unclamped = coord;
        coord = clamp(coord, uClampFrame.xy, uClampFrame.zw);

        outColor = texture(uTexture, coord, unclamped == coord ? 0.0 : -32.0);// lod-bias very negative to force lod 0

        `}};let V,W;class Rt extends q{constructor(){V??(V=pe({name:"tiling-sprite-shader",bits:[ut,Bt,me]})),W??(W=ge({name:"tiling-sprite-shader",bits:[lt,Ft,xe]}));const e=new S({uMapCoord:{value:new v,type:"mat3x3<f32>"},uClampFrame:{value:new Float32Array([0,0,1,1]),type:"vec4<f32>"},uClampOffset:{value:new Float32Array([0,0]),type:"vec2<f32>"},uTextureTransform:{value:new v,type:"mat3x3<f32>"},uSizeAnchor:{value:new Float32Array([100,100,.5,.5]),type:"vec4<f32>"}});super({glProgram:W,gpuProgram:V,resources:{localUniforms:new S({uTransformMatrix:{value:new v,type:"mat3x3<f32>"},uColor:{value:new Float32Array([1,1,1,1]),type:"vec4<f32>"},uRound:{value:0,type:"f32"}}),tilingUniforms:e,uTexture:w.EMPTY.source,uSampler:w.EMPTY.source.style}})}updateUniforms(e,t,r,s,n,a){const o=this.resources.tilingUniforms,u=a.width,d=a.height,h=a.textureMatrix,l=o.uniforms.uTextureTransform;l.set(r.a*u/e,r.b*u/t,r.c*d/e,r.d*d/t,r.tx/e,r.ty/t),l.invert(),o.uniforms.uMapCoord=h.mapCoord,o.uniforms.uClampFrame=h.uClampFrame,o.uniforms.uClampOffset=h.uClampOffset,o.uniforms.uTextureTransform=l,o.uniforms.uSizeAnchor[0]=e,o.uniforms.uSizeAnchor[1]=t,o.uniforms.uSizeAnchor[2]=s,o.uniforms.uSizeAnchor[3]=n,a&&(this.resources.uTexture=a.source,this.resources.uSampler=a.source.style)}}class Mt extends Q{constructor(){super({positions:new Float32Array([0,0,1,0,1,1,0,1]),uvs:new Float32Array([0,0,1,0,1,1,0,1]),indices:new Uint32Array([0,1,2,0,2,3])})}}function Gt(i,e){const t=i.anchor.x,r=i.anchor.y;e[0]=-t*i.width,e[1]=-r*i.height,e[2]=(1-t)*i.width,e[3]=-r*i.height,e[4]=(1-t)*i.width,e[5]=(1-r)*i.height,e[6]=-t*i.width,e[7]=(1-r)*i.height}function At(i,e,t,r){let s=0;const n=i.length/e,a=r.a,o=r.b,u=r.c,d=r.d,h=r.tx,l=r.ty;for(t*=e;s<n;){const c=i[t],f=i[t+1];i[t]=a*c+u*f+h,i[t+1]=o*c+d*f+l,t+=e,s++}}function kt(i,e){const t=i.texture,r=t.frame.width,s=t.frame.height;let n=0,a=0;i.applyAnchorToTexture&&(n=i.anchor.x,a=i.anchor.y),e[0]=e[6]=-n,e[2]=e[4]=1-n,e[1]=e[3]=-a,e[5]=e[7]=1-a;const o=v.shared;o.copyFrom(i._tileTransform.matrix),o.tx/=i.width,o.ty/=i.height,o.invert(),o.scale(i.width/r,i.height/s),At(e,2,0,o)}const R=new Mt;class Dt{constructor(){this.canBatch=!0,this.geometry=new Q({indices:R.indices.slice(),positions:R.positions.slice(),uvs:R.uvs.slice()})}destroy(){var e;this.geometry.destroy(),(e=this.shader)==null||e.destroy()}}class Ee{constructor(e){this._state=k.default2d,this._renderer=e}validateRenderable(e){const t=this._getTilingSpriteData(e),r=t.canBatch;this._updateCanBatch(e);const s=t.canBatch;if(s&&s===r){const{batchableMesh:n}=t;return!n._batcher.checkAndUpdateTexture(n,e.texture)}return r!==s}addRenderable(e,t){const r=this._renderer.renderPipes.batch;this._updateCanBatch(e);const s=this._getTilingSpriteData(e),{geometry:n,canBatch:a}=s;if(a){s.batchableMesh||(s.batchableMesh=new J);const o=s.batchableMesh;e.didViewUpdate&&(this._updateBatchableMesh(e),o.geometry=n,o.renderable=e,o.transform=e.groupTransform,o.setTexture(e._texture)),o.roundPixels=this._renderer._roundPixels|e._roundPixels,r.addToBatch(o,t)}else r.break(t),s.shader||(s.shader=new Rt),this.updateRenderable(e),t.add(e)}execute(e){const{shader:t}=this._getTilingSpriteData(e);t.groups[0]=this._renderer.globalUniforms.bindGroup;const r=t.resources.localUniforms.uniforms;r.uTransformMatrix=e.groupTransform,r.uRound=this._renderer._roundPixels|e._roundPixels,D(e.groupColorAlpha,r.uColor,0),this._state.blendMode=N(e.groupBlendMode,e.texture._source),this._renderer.encoder.draw({geometry:R,shader:t,state:this._state})}updateRenderable(e){const t=this._getTilingSpriteData(e),{canBatch:r}=t;if(r){const{batchableMesh:s}=t;e.didViewUpdate&&this._updateBatchableMesh(e),s._batcher.updateElement(s)}else if(e.didViewUpdate){const{shader:s}=t;s.updateUniforms(e.width,e.height,e._tileTransform.matrix,e.anchor.x,e.anchor.y,e.texture)}}_getTilingSpriteData(e){return e._gpuData[this._renderer.uid]||this._initTilingSpriteData(e)}_initTilingSpriteData(e){const t=new Dt;return t.renderable=e,e._gpuData[this._renderer.uid]=t,t}_updateBatchableMesh(e){const t=this._getTilingSpriteData(e),{geometry:r}=t,s=e.texture.source.style;s.addressMode!=="repeat"&&(s.addressMode="repeat",s.update()),kt(e,r.uvs),Gt(e,r.positions)}destroy(){this._renderer=null}_updateCanBatch(e){const t=this._getTilingSpriteData(e),r=e.texture;let s=!0;return this._renderer.type===j.WEBGL&&(s=this._renderer.context.supports.nonPowOf2wrapping),t.canBatch=r.textureMatrix.isSimple&&(s||r.source.isPowerOfTwo),t.canBatch}}Ee.extension={type:[p.WebGLPipes,p.WebGPUPipes,p.CanvasPipes],name:"tilingSprite"};const zt={name:"local-uniform-msdf-bit",vertex:{header:`
            struct LocalUniforms {
                uColor:vec4<f32>,
                uTransformMatrix:mat3x3<f32>,
                uDistance: f32,
                uRound:f32,
            }

            @group(2) @binding(0) var<uniform> localUniforms : LocalUniforms;
        `,main:`
            vColor *= localUniforms.uColor;
            modelMatrix *= localUniforms.uTransformMatrix;
        `,end:`
            if(localUniforms.uRound == 1)
            {
                vPosition = vec4(roundPixels(vPosition.xy, globalUniforms.uResolution), vPosition.zw);
            }
        `},fragment:{header:`
            struct LocalUniforms {
                uColor:vec4<f32>,
                uTransformMatrix:mat3x3<f32>,
                uDistance: f32
            }

            @group(2) @binding(0) var<uniform> localUniforms : LocalUniforms;
         `,main:`
            outColor = vec4<f32>(calculateMSDFAlpha(outColor, localUniforms.uColor, localUniforms.uDistance));
        `}},Vt={name:"local-uniform-msdf-bit",vertex:{header:`
            uniform mat3 uTransformMatrix;
            uniform vec4 uColor;
            uniform float uRound;
        `,main:`
            vColor *= uColor;
            modelMatrix *= uTransformMatrix;
        `,end:`
            if(uRound == 1.)
            {
                gl_Position.xy = roundPixels(gl_Position.xy, uResolution);
            }
        `},fragment:{header:`
            uniform float uDistance;
         `,main:`
            outColor = vec4(calculateMSDFAlpha(outColor, vColor, uDistance));
        `}},Wt={name:"msdf-bit",fragment:{header:`
            fn calculateMSDFAlpha(msdfColor:vec4<f32>, shapeColor:vec4<f32>, distance:f32) -> f32 {

                // MSDF
                var median = msdfColor.r + msdfColor.g + msdfColor.b -
                    min(msdfColor.r, min(msdfColor.g, msdfColor.b)) -
                    max(msdfColor.r, max(msdfColor.g, msdfColor.b));

                // SDF
                median = min(median, msdfColor.a);

                var screenPxDistance = distance * (median - 0.5);
                var alpha = clamp(screenPxDistance + 0.5, 0.0, 1.0);
                if (median < 0.01) {
                    alpha = 0.0;
                } else if (median > 0.99) {
                    alpha = 1.0;
                }

                // Gamma correction for coverage-like alpha
                var luma: f32 = dot(shapeColor.rgb, vec3<f32>(0.299, 0.587, 0.114));
                var gamma: f32 = mix(1.0, 1.0 / 2.2, luma);
                var coverage: f32 = pow(shapeColor.a * alpha, gamma);

                return coverage;

            }
        `}},Ot={name:"msdf-bit",fragment:{header:`
            float calculateMSDFAlpha(vec4 msdfColor, vec4 shapeColor, float distance) {

                // MSDF
                float median = msdfColor.r + msdfColor.g + msdfColor.b -
                                min(msdfColor.r, min(msdfColor.g, msdfColor.b)) -
                                max(msdfColor.r, max(msdfColor.g, msdfColor.b));

                // SDF
                median = min(median, msdfColor.a);

                float screenPxDistance = distance * (median - 0.5);
                float alpha = clamp(screenPxDistance + 0.5, 0.0, 1.0);

                if (median < 0.01) {
                    alpha = 0.0;
                } else if (median > 0.99) {
                    alpha = 1.0;
                }

                // Gamma correction for coverage-like alpha
                float luma = dot(shapeColor.rgb, vec3(0.299, 0.587, 0.114));
                float gamma = mix(1.0, 1.0 / 2.2, luma);
                float coverage = pow(shapeColor.a * alpha, gamma);

                return coverage;
            }
        `}};let O,E;class Et extends q{constructor(e){const t=new S({uColor:{value:new Float32Array([1,1,1,1]),type:"vec4<f32>"},uTransformMatrix:{value:new v,type:"mat3x3<f32>"},uDistance:{value:4,type:"f32"},uRound:{value:0,type:"f32"}});O??(O=pe({name:"sdf-shader",bits:[Ke,Je(e),zt,Wt,me]})),E??(E=ge({name:"sdf-shader",bits:[Ze,et(e),Vt,Ot,xe]})),super({glProgram:E,gpuProgram:O,resources:{localUniforms:t,batchSamplers:tt(e)}})}}class Lt extends nt{destroy(){this.context.customShader&&this.context.customShader.destroy(),super.destroy()}}class Le{constructor(e){this._renderer=e,this._renderer.renderableGC.addManagedHash(this,"_gpuBitmapText")}validateRenderable(e){const t=this._getGpuBitmapText(e);return e._didTextUpdate&&(e._didTextUpdate=!1,this._updateContext(e,t)),this._renderer.renderPipes.graphics.validateRenderable(t)}addRenderable(e,t){const r=this._getGpuBitmapText(e);le(e,r),e._didTextUpdate&&(e._didTextUpdate=!1,this._updateContext(e,r)),this._renderer.renderPipes.graphics.addRenderable(r,t),r.context.customShader&&this._updateDistanceField(e)}updateRenderable(e){const t=this._getGpuBitmapText(e);le(e,t),this._renderer.renderPipes.graphics.updateRenderable(t),t.context.customShader&&this._updateDistanceField(e)}_updateContext(e,t){const{context:r}=t,s=rt.getFont(e.text,e._style);r.clear(),s.distanceField.type!=="none"&&(r.customShader||(r.customShader=new Et(this._renderer.limits.maxBatchableTextures)));const n=st.graphemeSegmenter(e.text),a=e._style;let o=s.baseLineOffset;const u=it(n,a,s,!0),d=a.padding,h=u.scale;let l=u.width,c=u.height+u.offsetY;a._stroke&&(l+=a._stroke.width/h,c+=a._stroke.width/h),r.translate(-e._anchor._x*l-d,-e._anchor._y*c-d).scale(h,h);const f=s.applyFillAsTint?a._fill.color:16777215;for(let _=0;_<u.lines.length;_++){const g=u.lines[_];for(let m=0;m<g.charPositions.length;m++){const x=g.chars[m],P=s.chars[x];P!=null&&P.texture&&r.texture(P.texture,f||"black",Math.round(g.charPositions[m]+P.xOffset),Math.round(o+P.yOffset))}o+=s.lineHeight}}_getGpuBitmapText(e){return e._gpuData[this._renderer.uid]||this.initGpuText(e)}initGpuText(e){const t=new Lt;return e._gpuData[this._renderer.uid]=t,this._updateContext(e,t),t}_updateDistanceField(e){const t=this._getGpuBitmapText(e).context,r=e._style.fontFamily,s=Y.get(`${r}-bitmap`),{a:n,b:a,c:o,d:u}=e.groupTransform,d=Math.sqrt(n*n+a*a),h=Math.sqrt(o*o+u*u),l=(Math.abs(d)+Math.abs(h))/2,c=s.baseRenderedFontSize/e._style.fontSize,f=l*s.distanceField.range*(1/c);t.customShader.resources.localUniforms.uniforms.uDistance=f}destroy(){this._renderer=null}}Le.extension={type:[p.WebGLPipes,p.WebGPUPipes,p.CanvasPipes],name:"bitmapText"};function le(i,e){e.groupTransform=i.groupTransform,e.groupColorAlpha=i.groupColorAlpha,e.groupColor=i.groupColor,e.groupBlendMode=i.groupBlendMode,e.globalDisplayStatus=i.globalDisplayStatus,e.groupTransform=i.groupTransform,e.localDisplayStatus=i.localDisplayStatus,e.groupAlpha=i.groupAlpha,e._roundPixels=i._roundPixels}class It extends ye{constructor(e){super(),this.generatingTexture=!1,this._renderer=e,e.runners.resolutionChange.add(this)}resolutionChange(){const e=this.renderable;e._autoResolution&&e.onViewUpdate()}destroy(){this._renderer.htmlText.returnTexturePromise(this.texturePromise),this.texturePromise=null,this._renderer=null}}function $(i,e){const{texture:t,bounds:r}=i,s=e._style._getFinalPadding();at(r,e._anchor,t);const n=e._anchor._x*s*2,a=e._anchor._y*s*2;r.minX-=s-n,r.minY-=s-a,r.maxX-=s-n,r.maxY-=s-a}class Ie{constructor(e){this._renderer=e}validateRenderable(e){return e._didTextUpdate}addRenderable(e,t){const r=this._getGpuText(e);e._didTextUpdate&&(this._updateGpuText(e).catch(s=>{console.error(s)}),e._didTextUpdate=!1,$(r,e)),this._renderer.renderPipes.batch.addToBatch(r,t)}updateRenderable(e){const t=this._getGpuText(e);t._batcher.updateElement(t)}async _updateGpuText(e){e._didTextUpdate=!1;const t=this._getGpuText(e);if(t.generatingTexture)return;t.texturePromise&&(this._renderer.htmlText.returnTexturePromise(t.texturePromise),t.texturePromise=null),t.generatingTexture=!0,e._resolution=e._autoResolution?this._renderer.resolution:e.resolution;const r=this._renderer.htmlText.getTexturePromise(e);t.texturePromise=r,t.texture=await r;const s=e.renderGroup||e.parentRenderGroup;s&&(s.structureDidChange=!0),t.generatingTexture=!1,$(t,e)}_getGpuText(e){return e._gpuData[this._renderer.uid]||this.initGpuText(e)}initGpuText(e){const t=new It(this._renderer);return t.renderable=e,t.transform=e.groupTransform,t.texture=w.EMPTY,t.bounds={minX:0,maxX:1,minY:0,maxY:0},t.roundPixels=this._renderer._roundPixels|e._roundPixels,e._resolution=e._autoResolution?this._renderer.resolution:e.resolution,e._gpuData[this._renderer.uid]=t,t}destroy(){this._renderer=null}}Ie.extension={type:[p.WebGLPipes,p.WebGPUPipes,p.CanvasPipes],name:"htmlText"};function Ht(){const{userAgent:i}=_e.get().getNavigator();return/^((?!chrome|android).)*safari/i.test(i)}const Yt=new he;function He(i,e,t,r){const s=Yt;s.minX=0,s.minY=0,s.maxX=i.width/r|0,s.maxY=i.height/r|0;const n=y.getOptimalTexture(s.width,s.height,r,!1);return n.source.uploadMethodId="image",n.source.resource=i,n.source.alphaMode="premultiply-alpha-on-upload",n.frame.width=e/r,n.frame.height=t/r,n.source.emit("update",n.source),n.updateUvs(),n}function $t(i,e){const t=e.fontFamily,r=[],s={},n=/font-family:([^;"\s]+)/g,a=i.match(n);function o(u){s[u]||(r.push(u),s[u]=!0)}if(Array.isArray(t))for(let u=0;u<t.length;u++)o(t[u]);else o(t);a&&a.forEach(u=>{const d=u.split(":")[1].trim();o(d)});for(const u in e.tagStyles){const d=e.tagStyles[u].fontFamily;o(d)}return r}async function Xt(i){const t=await(await _e.get().fetch(i)).blob(),r=new FileReader;return await new Promise((n,a)=>{r.onloadend=()=>n(r.result),r.onerror=a,r.readAsDataURL(t)})}async function de(i,e){const t=await Xt(e);return`@font-face {
        font-family: "${i.fontFamily}";
        src: url('${t}');
        font-weight: ${i.fontWeight};
        font-style: ${i.fontStyle};
    }`}const F=new Map;async function jt(i,e,t){const r=i.filter(s=>Y.has(`${s}-and-url`)).map((s,n)=>{if(!F.has(s)){const{url:a}=Y.get(`${s}-and-url`);n===0?F.set(s,de({fontWeight:e.fontWeight,fontStyle:e.fontStyle,fontFamily:s},a)):F.set(s,de({fontWeight:t.fontWeight,fontStyle:t.fontStyle,fontFamily:s},a))}return F.get(s)});return(await Promise.all(r)).join(`
`)}function Nt(i,e,t,r,s){const{domElement:n,styleElement:a,svgRoot:o}=s;n.innerHTML=`<style>${e.cssStyle}</style><div style='padding:0;'>${i}</div>`,n.setAttribute("style",`transform: scale(${t});transform-origin: top left; display: inline-block`),a.textContent=r;const{width:u,height:d}=s.image;return o.setAttribute("width",u.toString()),o.setAttribute("height",d.toString()),new XMLSerializer().serializeToString(o)}function qt(i,e){const t=be.getOptimalCanvasAndContext(i.width,i.height,e),{context:r}=t;return r.clearRect(0,0,i.width,i.height),r.drawImage(i,0,0),t}function Qt(i,e,t){return new Promise(async r=>{t&&await new Promise(s=>setTimeout(s,100)),i.onload=()=>{r()},i.src=`data:image/svg+xml;charset=utf8,${encodeURIComponent(e)}`,i.crossOrigin="anonymous"})}class Ye{constructor(e){this._renderer=e,this._createCanvas=e.type===j.WEBGPU}getTexture(e){return this.getTexturePromise(e)}getTexturePromise(e){return this._buildTexturePromise(e)}async _buildTexturePromise(e){const{text:t,style:r,resolution:s,textureStyle:n}=e,a=A.get(Fe),o=$t(t,r),u=await jt(o,r,K.defaultTextStyle),d=mt(t,r,u,a),h=Math.ceil(Math.ceil(Math.max(1,d.width)+r.padding*2)*s),l=Math.ceil(Math.ceil(Math.max(1,d.height)+r.padding*2)*s),c=a.image,f=2;c.width=(h|0)+f,c.height=(l|0)+f;const _=Nt(t,r,s,u,a);await Qt(c,_,Ht()&&o.length>0);const g=c;let m;this._createCanvas&&(m=qt(c,s));const x=He(m?m.canvas:g,c.width-f,c.height-f,s);return n&&(x.source.style=n),this._createCanvas&&(this._renderer.texture.initSource(x.source),be.returnCanvasAndContext(m)),A.return(a),x}returnTexturePromise(e){e.then(t=>{this._cleanUp(t)}).catch(()=>{M("HTMLTextSystem: Failed to clean texture")})}_cleanUp(e){y.returnTexture(e,!0),e.source.resource=null,e.source.uploadMethodId="unknown"}destroy(){this._renderer=null}}Ye.extension={type:[p.WebGLSystem,p.WebGPUSystem,p.CanvasSystem],name:"htmlText"};class Kt extends ye{constructor(e){super(),this._renderer=e,e.runners.resolutionChange.add(this)}resolutionChange(){const e=this.renderable;e._autoResolution&&e.onViewUpdate()}destroy(){this._renderer.canvasText.returnTexture(this.texture),this._renderer=null}}class $e{constructor(e){this._renderer=e}validateRenderable(e){return e._didTextUpdate}addRenderable(e,t){const r=this._getGpuText(e);e._didTextUpdate&&(this._updateGpuText(e),e._didTextUpdate=!1),this._renderer.renderPipes.batch.addToBatch(r,t)}updateRenderable(e){const t=this._getGpuText(e);t._batcher.updateElement(t)}_updateGpuText(e){const t=this._getGpuText(e);t.texture&&this._renderer.canvasText.returnTexture(t.texture),e._resolution=e._autoResolution?this._renderer.resolution:e.resolution,t.texture=t.texture=this._renderer.canvasText.getTexture(e),$(t,e)}_getGpuText(e){return e._gpuData[this._renderer.uid]||this.initGpuText(e)}initGpuText(e){const t=new Kt(this._renderer);return t.renderable=e,t.transform=e.groupTransform,t.bounds={minX:0,maxX:1,minY:0,maxY:0},t.roundPixels=this._renderer._roundPixels|e._roundPixels,e._gpuData[this._renderer.uid]=t,t}destroy(){this._renderer=null}}$e.extension={type:[p.WebGLPipes,p.WebGPUPipes,p.CanvasPipes],name:"text"};class Xe{constructor(e){this._renderer=e}getTexture(e,t,r,s){typeof e=="string"&&(G("8.0.0","CanvasTextSystem.getTexture: Use object TextOptions instead of separate arguments"),e={text:e,style:r,resolution:t}),e.style instanceof L||(e.style=new L(e.style)),e.textureStyle instanceof H||(e.textureStyle=new H(e.textureStyle)),typeof e.text!="string"&&(e.text=e.text.toString());const{text:n,style:a,textureStyle:o}=e,u=e.resolution??this._renderer.resolution,{frame:d,canvasAndContext:h}=z.getCanvasAndContext({text:n,style:a,resolution:u}),l=He(h.canvas,d.width,d.height,u);if(o&&(l.source.style=o),a.trim&&(d.pad(a.padding),l.frame.copyFrom(d),l.updateUvs()),a.filters){const c=this._applyFilters(l,a.filters);return this.returnTexture(l),z.returnCanvasAndContext(h),c}return this._renderer.texture.initSource(l._source),z.returnCanvasAndContext(h),l}returnTexture(e){const t=e.source;t.resource=null,t.uploadMethodId="unknown",t.alphaMode="no-premultiply-alpha",y.returnTexture(e,!0)}renderTextToCanvas(){G("8.10.0","CanvasTextSystem.renderTextToCanvas: no longer supported, use CanvasTextSystem.getTexture instead")}_applyFilters(e,t){const r=this._renderer.renderTarget.renderTarget,s=this._renderer.filter.generateFilteredTexture({texture:e,filters:t});return this._renderer.renderTarget.bind(r,!1),s}destroy(){this._renderer=null}}Xe.extension={type:[p.WebGLSystem,p.WebGPUSystem,p.CanvasSystem],name:"canvasText"};b.add(Te);b.add(ve);b.add(Re);b.add(ot);b.add(Ae);b.add(De);b.add(ze);b.add(Xe);b.add($e);b.add(Le);b.add(Ye);b.add(Ie);b.add(Ee);b.add(Oe);b.add(Pe);b.add(we);
