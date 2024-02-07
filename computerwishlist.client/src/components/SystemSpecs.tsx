import { forwardRef, useEffect, useImperativeHandle, useState } from 'react';
import ComputerSpecCard from '../components/ComputerSpecCard';
import ComputerSpecAddEdit from '../components/ComputerSpecAddEdit';
import Modal from 'react-bootstrap/Modal';

export interface SystemSpecsProps {
  buttonName: string;  
  isAdmin: boolean;
  onDataChange(): void;
}export interface SystemSpecsRef {
  loadSpecs: () => void;
}

const SystemSpecs = forwardRef<SystemSpecsRef, SystemSpecsProps>((props, ref) => {

  const [systemComputerSpecs, setSystemComputerSpecs] = useState<ComputerSpec[]>();
  const [addEditComputerSpec, setAddEditComputerSpec] = useState<ComputerSpec | null>();
  console.log(props);
  useImperativeHandle(ref, () => ({
    loadSpecs() {
      LoadSystemComputerSpecs();
    }
  }));

  useEffect(() => {
    LoadSystemComputerSpecs();
  }, []);

  const contentsSystem = systemComputerSpecs === undefined
    ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
    : <div className="row">
      {systemComputerSpecs && systemComputerSpecs.length > 0 && systemComputerSpecs.map(systemComputerSpec =>
        <div className="col-3" key={systemComputerSpec.id}>
          <ComputerSpecCard computerSpec={systemComputerSpec} onAddToWishlist={() => onAddToWishlist(systemComputerSpec)} saveButtonText={props.buttonName} deleteComputerSpec={deleteComputerSpec} showDelete={props.isAdmin}></ComputerSpecCard><br />
        </div>
      )}
    </div>;

  return (
    <div>
      <h1 id="tabelLabel">Prebuilt Computer Specs</h1>
      {props.isAdmin ? <a className="btn btn-secondary" onClick={() => setAddEditComputerSpec({ id: -2, name: '', componentTypes: [] })}>Add new Configuration</a> : <></>}
      {contentsSystem}
      {addEditComputerSpec != null ?
        <Modal show={addEditComputerSpec != null} onHide={() => setAddEditComputerSpec(null)} size="lg">
          <Modal.Header closeButton>
            <Modal.Title>Modal heading</Modal.Title>
          </Modal.Header>
          <Modal.Body><ComputerSpecAddEdit computerSpec={addEditComputerSpec} saveComputerSpec={saveComputerSpec}></ComputerSpecAddEdit></Modal.Body>
        </Modal> :
        <></>}
    </div>
  );

  function LoadSystemComputerSpecs() {
    getSystemComputerSpecs();
  }

  function onAddToWishlist(computerSpec: ComputerSpec) {
    setAddEditComputerSpec(computerSpec);
  }

  async function deleteComputerSpec(id: number) { 
    const response = await fetch('computerspec/deletecomputerspec',
      {
        method: "POST",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ computerSpecId: id })
      }
    );
    const data = await response.json();
    if (data.success) {
      props.onDataChange();
    }
  }
  async function saveComputerSpec(computerSpec: ComputerSpec) {
    const useridCookieValue = getCookie("userid");
    let userId: number = -1;
    if (useridCookieValue !== undefined) userId = parseInt(useridCookieValue);
    const response = await fetch('computerspec/savecomputerspec',
      {
        method: "POST",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ computerSpec: computerSpec, isAdmin: props.isAdmin, userId: userId })
      }
    );
    const data = await response.json();
    if (data.success) {
      setAddEditComputerSpec(null);
      props.onDataChange();
    }
  }

  function getCookie(key: string) {
    const b = document.cookie.match("(^|;)\\s*" + key + "\\s*=\\s*([^;]+)");
    return b ? b.pop() : "";
  }

  async function getSystemComputerSpecs() {
    const response = await fetch('computerspec/getsystemcomputerspecs',
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
    setSystemComputerSpecs(data.computerSpecs);
  }
});

export default SystemSpecs;