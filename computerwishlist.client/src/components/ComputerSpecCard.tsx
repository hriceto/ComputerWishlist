interface ComputerSpecCardProps {
  computerSpec: ComputerSpec;
  onAddToWishlist(): void;
  deleteComputerSpec(id: number): void;
  saveButtonText: string;
  showDelete: boolean;
}

function ComputerSpecCard({ computerSpec, onAddToWishlist, deleteComputerSpec, saveButtonText, showDelete }: ComputerSpecCardProps) {
  return (
      <div className="card">
          <div className="card-body">
              <h5 className="card-title">{computerSpec.name}</h5>
              <div className="card-text">
                  {computerSpec.componentTypes.map((componentType: ComponentType) => {
                      return (
                          <div key={componentType.id}>
                              <strong>{componentType.name}</strong>:&nbsp;
                              {componentType.components.map((component: Component, j) => {
                                  return <span key={component.id}>{component.count > 1 ? component.count : ''}{component.name} {(component.count > 1 && j < componentType.components.length - 1) ? ',' : ''} </span>
                                }
                              )
                              }
                          </div>
                      )
                  })}
              </div>
        <a className="btn btn-primary" onClick={onAddToWishlist}>{saveButtonText}</a>
        {showDelete && <a className="btn btn-danger" onClick={() => deleteComputerSpec(computerSpec.id)}>Delete</a>}
          </div>
      </div>
  );
}

export default ComputerSpecCard;