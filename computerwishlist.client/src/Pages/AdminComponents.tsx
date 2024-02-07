import { useEffect, useState } from "react";
import { Modal } from "react-bootstrap";
import ComponentTypeAddEdit from "../components/ComponentTypeAddEdit";

function AdminComponents() {
  const [allComponentTypes, setAllComponentTypes] = useState<ComponentType[]>();
  const [addEditComponentType, setAddEditComponentType] = useState<ComponentType | null>();

  useEffect(() => {
    getComponentTypes();
  }, []);

  return (
    <div>
      <h1 id="tabelLabel">Admin Computer Components</h1>
      {<a className="btn btn-secondary" onClick={() => setAddEditComponentType({ id: -2, name: '', components: [] })}>Add new Component Type</a>}
      <table>
        <tbody>
      {allComponentTypes && allComponentTypes.map((componentType: ComponentType) => {
        return (<tr key={componentType.id}>
          <td>{componentType.name}</td>
          <td><a className="btn btn-primary" onClick={() => setAddEditComponentType(componentType)}>Edit</a></td>
          <td><a className="btn btn-danger" onClick={() => deleteComponentType(componentType.id)}>Delete</a></td>
        </tr>)
      }
          )}
        </tbody>
      </table>
      {addEditComponentType != null ?
        <Modal show={addEditComponentType != null} onHide={() => setAddEditComponentType(null)} size="lg">
          <Modal.Header closeButton>
            <Modal.Title>Modal heading</Modal.Title>
          </Modal.Header>
          <Modal.Body><ComponentTypeAddEdit componentType={addEditComponentType} saveComponentType={saveComponentType}></ComponentTypeAddEdit></Modal.Body>
        </Modal> :
        <></>}
    </div>
  );

  async function deleteComponentType(id: number) {
    const response = await fetch('componenttype/deletecomponenttype',
      {
        method: "POST",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ componentTypeId: id })
      }
    );
    const data = await response.json();
    if (data.success) {
      getComponentTypes();
    }
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

  async function saveComponentType(componentType: ComponentType) {
    const response = await fetch('componenttype/savecomponenttype',
      {
        method: "POST",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ componentType: componentType })
      }
    );
    const data = await response.json();
    if (data.success) {
      setAddEditComponentType(null);
      getComponentTypes();
    }
  }
}

export default AdminComponents;