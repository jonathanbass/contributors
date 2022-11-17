import { Grid } from "@mui/material";
import { Container } from "@mui/system";
import { useEffect, useState } from "react";
import { useLoaderData } from "react-router-dom";
import Contributer from "./Contributer";
import { ContributersClient, IContributer } from "./ContributersClient";

interface IRouteData {
    owner: string;
    repository: string;
}

export async function loader({ params }: any) {
    return params;
}

function Contributers() {
    const routeData = useLoaderData() as IRouteData;

    const [contributers, setContributers] = useState([] as IContributer[]);

    useEffect(() => {
        (async () => {
            const data = await ContributersClient.getContributers(routeData.owner, routeData.repository);
            setContributers(data);
        })();
    }, []);

    return <Container>
        <Grid container marginTop={0} spacing={3}>
            {contributers.map(contributer => (
                <Contributer name={contributer.name} email={contributer.email} date={contributer.date} />
            ))}
        </Grid>
    </Container>;
}

export default Contributers;
