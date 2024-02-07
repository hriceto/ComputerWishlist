interface ComputerSpec {
    id: number;
    name: string;
    componentTypes: ComponentType[];
}

interface ComponentType {
    id: number;
    name: string;
    components: Component[];
}

interface Component {
    id: number;
    name: string;
    count: number;
}