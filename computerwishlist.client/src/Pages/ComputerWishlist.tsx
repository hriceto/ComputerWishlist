import { createRef } from 'react';
import SystemSpecs, { SystemSpecsRef } from '../components/SystemSpecs';
import UserSpecs, { UserSpecsRef } from '../components/UserSpecs';

function ComputerWishlist() {

  const systemSpecRef = createRef<SystemSpecsRef>();
  const userSpecRef = createRef<UserSpecsRef>();

  return (
    <div>
      <UserSpecs ref={userSpecRef} buttonName="Edit Configuration" onDataChange={onDataChange}></UserSpecs>
      <SystemSpecs ref={systemSpecRef} buttonName="Add to Wishlist" onDataChange={onDataChange} isAdmin={false}></SystemSpecs>
    </div>
  );

  function onDataChange() {
    systemSpecRef.current?.loadSpecs();
    userSpecRef.current?.loadSpecs();
  }
}

export default ComputerWishlist;