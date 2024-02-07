import { ReactNode } from "react";

interface LayoutProps {
    children: ReactNode;
}

function Layout({ children }: LayoutProps) {
       

    return (
        <>
            <div className="row">
                <nav className="navbar navbar-expand-lg navbar-light bg-light">
                    <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>

                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav mr-auto">
                            <li className="nav-item active">
                                <a className="nav-link" href="/">Computer Wishlist</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="/admin-prebuilt">Admin Prebuilt Computer Specs</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="/admin-components">Admin Computer Compopnents</a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
            <div className="row">{children}</div>
        </>
    );
}

export default Layout;