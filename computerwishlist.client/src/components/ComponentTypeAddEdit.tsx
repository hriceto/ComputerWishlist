import { useState } from "react";
import { Button } from "react-bootstrap";

interface ComponentTypeAddEditProps {
  componentType: ComponentType;
  saveComponentType(componentType: ComponentType): void;
}

function ComponentTypeAddEdit({ componentType, saveComponentType }: ComponentTypeAddEditProps) {

  const [addEditComponentType, setAddEditComponentType] = useState<ComponentType>({ id: -1, name: '', components: [] });
  if (addEditComponentType === undefined || addEditComponentType.id == -1) setAddEditComponentType(componentType);

  const addEditContents = addEditComponentType === undefined
    ? <p>Loading...</p>
    : <>
      <div className="row">
        <div className="col-4">
          Name:
        </div>
        <div className="col-8">
          <input type="text" value={addEditComponentType.name} onChange={(e) => { setAddEditComponentType(prev => ({ ...prev, name: e.target.value })) }}></input>
        </div>

        <div className="row">
          <div className="col-12"><br /></div>
        </div>

        <div className="row">
          <div className="col-4">
            Options
            <br />
            <a className="btn btn-secondary" onClick={() => addComponent()}>Add Blank Option</a>
          </div>
          <div className="col-8">
              {componentType &&
                componentType.components.map((component: Component) => {
                  return (
                    <div className="row" key={component.id}>
                    <div className="col-10" >
                      <input type="text" value={component.name} onChange={(e) => { componentTypeChanged(e.target.value, component.id) }}></input>
                      <br />
                    </div>
                    <div className="col-2">
                        <a className="btn btn-danger" onClick={() => removeComponent(component.id)}>Remove</a>
                      <br />
                    </div>
                    </div>
                  )
                })
              }<br />
          </div>
        </div>
      </div>
      <div className="row">
        <div className="col-12">
          <Button variant="primary" onClick={() => saveComponentType(addEditComponentType)}>
            Save Changes
          </Button>
        </div>
      </div>
    </>
  return (
    addEditContents
  );

  function componentTypeChanged(name: string, componentId: number) {
    const components = addEditComponentType.components;
    components.forEach((component) => {
      if (component.id == componentId) {
        component.name = name;
      }
    });
    setAddEditComponentType(prev => ({ ...prev, components: components }));
  }
  function removeComponent(componentId:number) {
    const components = addEditComponentType.components;
    const componentToRemove = components.filter((componet => componet.id == componentId))[0];
    components.splice(components.indexOf(componentToRemove), 1);
    setAddEditComponentType(prev => ({ ...prev, components: components }));
  }

  function addComponent() {
    const components = addEditComponentType.components;
    let minId = Math.min(...components.map(componet => componet.id));
    if (minId >= 0) minId = -1;
    minId--;
    components.push({ id: minId, count: 1, name: '' });
    setAddEditComponentType(prev => ({ ...prev, components: components }));
  }
}

export default ComponentTypeAddEdit;