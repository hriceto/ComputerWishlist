import { forwardRef, useEffect, useImperativeHandle, useState } from 'react';
import ComputerSpecCard from '../components/ComputerSpecCard';
import ComputerSpecAddEdit from '../components/ComputerSpecAddEdit';
import Modal from 'react-bootstrap/Modal';

export interface UserSpecsProps {
  buttonName: string;
  onDataChange(): void;
}export interface UserSpecsRef {
  loadSpecs: () => void;
}

const UserSpecs = forwardRef<UserSpecsRef, UserSpecsProps>((props, ref) => {

  const [userComputerSpecs, setUserComputerSpecs] = useState<ComputerSpec[]>();
  const [addEditComputerSpec, setAddEditComputerSpec] = useState<ComputerSpec | null>();
  console.log(props);
  useImperativeHandle(ref, () => ({
    loadSpecs() {
      LoadUserComputerSpecs();
    }
  }));

  useEffect(() => {
    LoadUserComputerSpecs();
  }, []);

  const contentsUser = userComputerSpecs === undefined
    ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
    : <div className="row">
      {userComputerSpecs && userComputerSpecs.length > 0 && userComputerSpecs.map(userComputerSpec =>
        <div className="col-3" key={userComputerSpec.id}>
          <ComputerSpecCard computerSpec={userComputerSpec} onAddToWishlist={() => onAddToWishlist(userComputerSpec)} saveButtonText={props.buttonName} deleteComputerSpec={deleteComputerSpec} showDelete={true}></ComputerSpecCard><br />
        </div>
      )}
    </div>;

  return (
    <div>
      {contentsUser && <h1 id="tabelLabel">Your Wishlist Specs</h1>}
      {<a className="btn btn-secondary" onClick={() => setAddEditComputerSpec({ id: -2, name: '', componentTypes: [] })}>Add new Configuration</a>}
      {contentsUser}
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

  function LoadUserComputerSpecs() {

    const useridCookieValue = getCookie("userid");
    if (useridCookieValue === undefined || useridCookieValue == "") {
      createUser().then((userId: number) => {
        setCookie("userid", userId.toString(), 365);
        getUserComputerSpecs(userId);
      });
    }
    else {
      getUserComputerSpecs(parseInt(useridCookieValue));
    }
  }


  function onAddToWishlist(computerSpec: ComputerSpec) {
    setAddEditComputerSpec(computerSpec);
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
        body: JSON.stringify({ computerSpec: computerSpec, isAdmin: false, userId: userId })
      }
    );
    const data = await response.json();
    if (data.success) {
      setAddEditComputerSpec(null);
      props.onDataChange();
    }
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

  function getCookie(key: string) {
    const b = document.cookie.match("(^|;)\\s*" + key + "\\s*=\\s*([^;]+)");
    return b ? b.pop() : "";
  }
  function setCookie(name: string, value: string, days: number) {
    let expires = "";
    if (days) {
      let date = new Date();
      date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
      expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
  }

  async function getUserComputerSpecs(userId: number) {
    const response = await fetch('computerspec/getusercomputerspecs',
      {
        method: "POST",
        mode: "cors",
        cache: "no-cache",
        credentials: "same-origin",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ userId: userId })
      }
    );
    const data = await response.json();
    setUserComputerSpecs(data.computerSpecs);
  }

  async function createUser() {
    const response = await fetch('user/createuser',
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
    return data.userId;
  }
});

export default UserSpecs;