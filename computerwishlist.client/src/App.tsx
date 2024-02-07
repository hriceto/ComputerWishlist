import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import ComputerWishlist from './Pages/ComputerWishlist';
import AdminPrebuilt from './Pages/AdminPrebuilt';
import Layout from './Layout';
import AdminComponents from './Pages/AdminComponents';


function App() {

    const router = createBrowserRouter([
        {
            path: "/",
            element: <ComputerWishlist />,
        },
        {
            path: "/admin-prebuilt",
            element: <AdminPrebuilt />,
        },
        {
            path: "/admin-components",
            element: <AdminComponents />,
        },
    ]);


    return (
        <Layout>
            <RouterProvider router={router} />
        </Layout>
    );
}

export default App;