import { createRef } from 'react';
import SystemSpecs, { SystemSpecsRef } from '../components/SystemSpecs';

function AdminPrebuilt() {

  const systemSpecRef = createRef<SystemSpecsRef>();

  return (
    <div>
      <SystemSpecs ref={systemSpecRef} buttonName="Edit Configuration" onDataChange={onDataChange} isAdmin={true}></SystemSpecs>
    </div>
  );

  function onDataChange() {
    systemSpecRef.current?.loadSpecs();
  }
}

export default AdminPrebuilt;