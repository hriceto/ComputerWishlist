import { useEffect, useState } from "react";
import { Button } from "react-bootstrap";

interface ComputerSpecAddEditProps {
    computerSpec: ComputerSpec;
    saveComputerSpec(computerSpec: ComputerSpec): void;
}

function ComputerSpecAddEdit({ computerSpec, saveComputerSpec }: ComputerSpecAddEditProps) {

    const [addEditComputerSpec, setAddEditComputerSpec] = useState<ComputerSpec>({ id: -1, name: '', componentTypes: [] });
    const [allComponentTypes, setAllComponentTypes] = useState<ComponentType[]>();
    if (addEditComputerSpec === undefined || addEditComputerSpec.id == -1) setAddEditComputerSpec(computerSpec);

    useEffect(() => {

        getComponentTypes();
    }, []);

    const addEditContents = addEditComputerSpec === undefined
        ? <p>Loading...</p>
        :<>
        <div className="row">
            <div className="col-4">
                Name:
            </div>
            <div className="col-8">
                <input type="text" value={addEditComputerSpec.name} onChange={(e) => { setAddEditComputerSpec(prev => ({ ...prev, name: e.target.value })) }}></input>
            </div>

          {allComponentTypes && allComponentTypes.map((componentType: ComponentType) => {
              const addEditCompomentType = addEditComputerSpec.componentTypes.filter((ct => ct.id == componentType.id))[0]
                return (
                    <div className="row" key={componentType.id}>
                        <div className="col-4">
                            {componentType.name}
                        </div>
                        <div className="col-8">
                            <div className="row">
                            {allComponentTypes &&
                                componentType.components.map((component: Component) => {
                                    return (
                                        <div className="col-3" key={component.id}>
                                        <input type="checkbox" checked={addEditCompomentType && addEditCompomentType.components.filter((ct) => ct.id == component.id).length > 0} onChange={(e) => componentTypeChanged(e, componentType.id, component.id)}></input>{component.name}<br />
                                        </div>
                                    )
                                })
                                }
                            </div><br />
                        </div>
                    </div>
                )
            })}
            </div>
            <div className="row">
                <div className="col-12">
                    <Button variant="primary" onClick={() => saveComputerSpec(addEditComputerSpec)}>
                        Save Changes
                    </Button>
                </div>
            </div>
        </>
  return (
      addEditContents
    );

    function componentTypeChanged(e: React.ChangeEvent<HTMLInputElement>, componentTypeId: number, componentId: number)
    {
      const componentTypes = addEditComputerSpec.componentTypes;
      let found = false;
        componentTypes.forEach((componentType) => {
            if (componentType.id == componentTypeId) {
                if (e.target.checked) {
                  componentType.components.push({ count: 1, id: componentId, name: "" });
                  found = true;
                }
                else {
                    componentType.components.forEach((component, i) => {
                        if (component.id === componentId) componentType.components.splice(i, 1);
                    });
                }
            }
        });
      console.log(e.target.checked);
      console.log(found);
      console.log(componentTypes);
      if (e.target.checked && !found) {
        componentTypes.push({ id: componentId, name: '', components: [{ count: 1, id: componentId, name:'' }] })
      }
      console.log(componentTypes);
        setAddEditComputerSpec(prev => ({ ...prev, componentTypes: componentTypes }));
    }

    async function getComponentTypes() {
        const response = await fetch('componenttype/getcomponenttypes',
            {
                method: "POST",
                mode: "cors",
                cache: "no-cache",
                credentials: "same-origin",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({})
            }
        );
        const data = await response.json();
        setAllComponentTypes(data.componentTypes);
    }
}

export default ComputerSpecAddEdit;